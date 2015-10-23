using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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

        #region create

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

        #endregion

        #region edit

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int postId)
        {
            var post = postRepository.GetPost(postId);
            var postInfo = (PostInfo)ModelMapper.Map(post, typeof(Post), typeof(PostInfo));
            return View(postInfo);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(PostInfo postInfo)
        {
            if (ModelState.IsValid)
            {
                var post = postRepository.GetPost(postInfo.PostId);
                post.Header = postInfo.Header;
                post.Content = postInfo.Content;
                post.DateLastEdited = DateTime.Now;
                postRepository.SavePost(post);
                return RedirectToAction("List", "Post");

            }

            return View(postInfo);
        }

        #endregion

        #region Add piece

        [HttpGet]
        [Authorize]
        public ActionResult CreatePiece(int postId)
        {
            return View(new PieceInfo{PostId = postId});
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreatePiece(PieceInfo postInfo)
        {
            if (ModelState.IsValid)
            {

                var post = postRepository.GetPost(postInfo.PostId);
                var piece = new PieceContent
                {
                    Post = post,
                    Content = postInfo.Content,
                    Header = postInfo.Header
                };
                
                postRepository.SavePieceContent(piece);
                return RedirectToAction("ShowPost", new {postId = post.PostId});

            }

            return View(postInfo);
        }

        #endregion

        #region edit piece

        [HttpGet]
        [Authorize]
        public ActionResult EditPiece(int pieceId)
        {
            var piece = postRepository.GetPiece(pieceId);
            var pieceInfo = new PieceInfo
            {
                Content = piece.Content,
                Header = piece.Header,
                PieceContentId = pieceId,
                PostId = piece.Post.PostId
            };
            return View(pieceInfo);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditPiece(PieceInfo pieceInfo)
        {
            if (ModelState.IsValid)
            {
                var piece = postRepository.GetPiece(pieceInfo.PieceContentId);
                piece.Content = pieceInfo.Content;
                piece.Header = pieceInfo.Header;

                postRepository.SavePieceContent(piece);
                return RedirectToAction("ShowPost", new { postId = piece.Post.PostId });
            }

            return View(pieceInfo);
        }

        public ActionResult DeletePiece(int pieceId, int postId)
        {
            postRepository.DeletePiece(pieceId);
            return RedirectToAction("ShowPost", new { postId = postId });
        }

        #endregion

        #region detail post

        public ActionResult ShowPost(int postId)
        {
            var post = postRepository.GetPost(postId);
            return View(post);
        }

        #endregion


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

        public ActionResult Delete(int id)
        {
            postRepository.DeletePost(id);
            return RedirectToAction("List");
        }
	}
}