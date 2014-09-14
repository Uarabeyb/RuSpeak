using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using RuSpeak.App_Start;
using RuSpeak.Models;
using RuSpeak.Models.Things;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PreStartApp), "Start")]
namespace RuSpeak.App_Start
{
    public static class PreStartApp
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Метод запускается один раз перед стартом приложения        
        /// </summary>
        public static void Start()
        {
            _logger.Info("Application PreStart");


            //using (var context = new MyContext())
            //{
            //    var au = context.AudioContents.ToList();
            //    foreach (var VARIABLE in context.Posts)
            //    {
            //        VARIABLE.AudioContent = null;
            //        context.Posts.Attach(VARIABLE);
            //        context.Entry(VARIABLE).State = EntityState.Modified;
            //        context.SaveChanges();
            //    }
            //    foreach (var VARIABLE in au)
            //    {
            //        context.AudioContents.Remove(VARIABLE);
            //        context.SaveChanges();
            //    }
                
            //    var au3 = context.AudioContents.ToList();
            //    Stream fs = File.OpenRead(@"C:\Users\vinnik\Downloads\jason_derulo_feat._snoop_dogg_-_wiggle_(zaycev.net).mp3");
            //    var audio = new AudioContent();
            //    using (var memoryStream = new MemoryStream())
            //    {
            //        fs.CopyTo(memoryStream);
            //        audio.AudioStream = memoryStream.ToArray();
            //        audio.Name = "_snoop_dogg_-_wiggle_(zaycev.net)";
            //    }
            //    var post = context.Posts.First();

            //    post.AudioContent = audio;
            //    try
            //    {
            //        context.Posts.Attach(post);
            //        context.Entry(post).State = EntityState.Modified;
            //        context.SaveChanges();
            //        var au2 = context.AudioContents.ToList();
            //    }
            //    catch (Exception e)
            //    {

            //        throw;
            //    }

                //    var piece1 = new PieceContent()
                //    {
                //        Header = "Part 1",
                //        Content =
                //            "Тут будет контент первого кусочка. Текста может быть много, он может быть нужным, но для теста именно столько и нужно."
                //    };
                //    var piece2 = new PieceContent()
                //    {
                //        Header = "Part 1",
                //        Content =
                //            "Тут будет контент первого кусочка. Текста может быть много, он может быть нужным, но для теста именно столько и нужно."
                //    };
                //    var piece3 = new PieceContent()
                //    {
                //        Header = "Part 1",
                //        Content =
                //            "Тут будет контент первого кусочка. Текста может быть много, он может быть нужным, но для теста именно столько и нужно."
                //    };
                //    var piece4 = new PieceContent()
                //    {
                //        Header = "Part 1",
                //        Content =
                //            "Тут будет контент первого кусочка. Текста может быть много, он может быть нужным, но для теста именно столько и нужно."
                //    };
                //    var piece5 = new PieceContent()
                //    {
                //        Header = "Part 1",
                //        Content =
                //            "Тут будет контент первого кусочка. Текста может быть много, он может быть нужным, но для теста именно столько и нужно."
                //    };

                //    var post = new Post(){DateCreated = DateTime.Now};
                //    post.UserPosted = context.Users.First();
                //    post.Header = "Первый пост";
                //    post.Content = "тут немножко контента поста";
                //    post.Pieces.Add(piece1);
                //    post.Pieces.Add(piece2);
                //    post.Pieces.Add(piece3);

                //    var post2 = new Post { DateCreated = DateTime.Now };
                //    post2.UserPosted = context.Users.First();
                //    post2.Header = "Второй пост";
                //    post2.Content = "тут немножко контента поста";
                //    post2.Pieces.Add(piece4);
                //    post2.Pieces.Add(piece5);

                //    context.Posts.Add(post);
                //    context.Posts.Add(post2);
                //    context.SaveChanges();
            //}
        }
    }
}