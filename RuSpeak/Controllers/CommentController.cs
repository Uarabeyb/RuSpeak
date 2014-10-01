using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RuSpeak.DAL.Abstract;
using RuSpeak.Models.Auth;
using RuSpeak.Models.Things;

namespace RuSpeak.Controllers
{
    public class CommentController : BaseController
    {
        private ICommentRepository repository;

        public CommentController(ICommentRepository _repo)
        {
            repository = _repo;
        }







        [HttpGet]
        [Authorize]
        public ActionResult Create(int postId, int commentId = 0)
        {
            var commentInfo = new CommentInfo {PostId = postId, CommentId = commentId};
            return View(commentInfo);
        }


        [HttpPost]
        [Authorize]
        public ActionResult Create(CommentInfo commentInfo)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment();
                comment.Date = DateTime.Now;
                comment.Text = commentInfo.Text;
                comment.Post = new Post() { PostId = commentInfo.PostId};
                comment.UserPosted = CurrentUser;

                if (commentInfo.CommentId != 0)
                    comment.ToComment = new Comment { CommentId = commentInfo.CommentId };

                repository.SaveComment(comment);
                return RedirectToAction("ShowPost", "Post", new { postId = commentInfo.PostId});
            }
            return View(commentInfo);
        }
	}
}