using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuSpeak.Models.Things;

namespace RuSpeak.DAL.Abstract
{
    public interface IPostRepository
    {
        IEnumerable<Post> Posts { get; }
        void SavePost(Post post);
        void DeletePost(int id);
        Post GetPost(int id);

        PieceContent GetPiece(int id);
        void SavePieceContent(PieceContent piece);
        void DeletePiece(int pieceid);
        void RemovePieceContent(int pieceId);
    }
}