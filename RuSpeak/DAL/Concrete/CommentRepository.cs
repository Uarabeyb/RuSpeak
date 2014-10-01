using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RuSpeak.DAL.Abstract;
using RuSpeak.Models;
using RuSpeak.Models.Things;

namespace RuSpeak.DAL.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        public IEnumerable<Comment> GetComments(int postId)
        {
            using (var context = new MyContext())
            {
                return context.Comments.Where(x => x.Post.PostId == postId).ToList();
            }
        }

        public void SaveComment(Comment comment)
        {
            using (var context = new MyContext())
            {
                if (comment.CommentId == 0)
                {
                    context.Users.Attach(comment.UserPosted);
                    context.Posts.Attach(comment.Post);
                    context.Comments.Add(comment);
                }
                else
                {
                    context.Comments.Attach(comment);
                    context.Entry(comment).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public void DeleteComment(int commentId)
        {
            using (var context = new MyContext())
            {
                var comment = context.Comments.FirstOrDefault(t => t.CommentId == commentId);
                if (comment != null)
                {
                    context.Comments.Remove(comment);
                    context.SaveChanges();
                }
            }
        }
    }
}