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
    public class PostRepository : IPostRepository
    {
        public IEnumerable<Post> Posts 
        {
            get
            {
                using (var context = new MyContext())
                {
                    return context.Posts.Include("AudioContent").ToList();
                    //return (from p in context.Posts
                    //    select new {p.Header}).ToList();
                }        
            }
        }
        public void SavePost(Post post)
        {
            using (var context = new MyContext())
            {
                if (post.PostId == 0)
                {
                    context.Users.Attach(post.UserPosted);
                    context.Posts.Add(post);
                }
                else
                {
                    context.Posts.Attach(post);
                    context.Entry(post).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }
        public void DeletePost(int id)
        {
            using (var context = new MyContext())
            {
                var post = context.Posts.FirstOrDefault(t => t.PostId == id);
                if (post != null)
                {
                    context.Posts.Remove(post);
                    context.SaveChanges();
                }
            }
        }
        public Post GetPost(int id)
        {
            using (var context = new MyContext())
            {
                return context.Posts.Include("AudioContent").Include("Pieces").Include("Comments").SingleOrDefault(p => p.PostId == id);
            }
        }

        public void SavePieceContent(PieceContent piece)
        {
            using (var context = new MyContext())
            {
                if (piece.PieceContentId == 0)
                {
                    context.Posts.Attach(piece.Post);
                    context.Pieces.Add(piece);
                }
                else
                {
                    context.Pieces.Attach(piece);
                    context.Entry(piece).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }
        public void RemovePieceContent(int pieceId)
        {
            using (var context = new MyContext())
            {
                var piece = context.Pieces.FirstOrDefault(t => t.PieceContentId == pieceId);
                if (piece != null)
                {
                    context.Pieces.Remove(piece);
                    context.SaveChanges();
                }
            }
        }
    }
}