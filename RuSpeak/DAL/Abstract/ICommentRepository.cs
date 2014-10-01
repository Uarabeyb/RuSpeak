using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuSpeak.Models.Things;

namespace RuSpeak.DAL.Abstract
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetComments(int postId); 
        void SaveComment(Comment comment);
        void DeleteComment(int commentId);
    }
}