using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RuSpeak.DAL.Abstract;
using RuSpeak.Models;
using RuSpeak.Models.Things;

namespace RuSpeak.Controllers
{
    public class PostController : BaseController
    {
        private IPostRepository postRepository;
        private IUserRepository userRepository;

        public PostController(IPostRepository postRepository, IUserRepository userRepository)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;
        }

        public ActionResult List()
        {
            return View(postRepository.Posts.OrderByDescending(x=>x.DateCreated));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View(new PostInfo());
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Create(PostInfo postInfo)
        {
            if (ModelState.IsValid)
            {
                
                var post = (Post)ModelMapper.Map(postInfo, typeof(PostInfo), typeof(Post));

                var audio = Request.Files["audio"];
                if (audio != null && audio.ContentLength > 0)
                {
                    var audioContent = new AudioContent();
                    audioContent.Name = audio.FileName;
                    var audioArray = new byte[audio.ContentLength];
                    audio.InputStream.Read(audioArray, 0, audio.ContentLength);
                    audioContent.AudioStream = audioArray;
                    post.AudioContent = audioContent;
                }

                post.DateCreated = DateTime.Now;
                post.UserPosted = userRepository.GetUser(CurrentUser.UserId);
                postRepository.SavePost(post);
                return RedirectToAction("List", "Post");
                
            }

            return View(postInfo);
        }

        public ActionResult AudioStream(int audioId)
        {
            using (var context = new MyContext())
            {
                var audio = context.AudioContents.Find(audioId);
                if (audio != null) 
                    return File(audio.AudioStream, "audio/mpeg");
                return null;
            }
        }

        [HttpGet]
        public ActionResult UploadAudio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadAudio(HttpPostedFileBase file) 
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            postRepository.DeletePost(id);
            return RedirectToAction("List");
        }
	}
}