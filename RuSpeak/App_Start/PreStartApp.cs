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
        }
    }
}