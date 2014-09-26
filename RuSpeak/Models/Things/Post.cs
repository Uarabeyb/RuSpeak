using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using JetBrains.Annotations;
using RuSpeak.Models.Auth;

namespace RuSpeak.Models.Things
{
    public class Post : BaseContent
    {
        [Key]
        public int PostId { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual User UserPosted { get; set; }

        public virtual ICollection<PieceContent> Pieces { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Pieces = new HashSet<PieceContent>();
            Comments = new HashSet<Comment>();
        }
    }

    public class PieceContent : BaseContent
    {
        [Key]
        public int PieceContentId { get; set; }
        public virtual Post Post { get; set; }
    }

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public virtual Comment ToComment { get; set; }
        public virtual Post Post{get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }

    public class PostInfo 
    {
        [Required]
        [StringLength(200, ErrorMessage = "Название поста \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 4)]
        public string Header { get; set; }

        [Required]
        [StringLength(3999, ErrorMessage = "Основное тело поста \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 4)]
        public string Content { get; set; }
    }
}