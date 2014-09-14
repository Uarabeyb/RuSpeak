using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RuSpeak.App_Start;
using RuSpeak.Infrastructure;
using RuSpeak.Models;
using RuSpeak.Models.Auth;

namespace RuSpeak
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles); BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        public override void Init()
        {
            _logger.Info("Application Init");
        }

        public override void Dispose()
        {
            _logger.Info("Application Dispose");
        }

        protected void Application_Error()
        {
            _logger.Info("Application Error");
        }


        protected void Application_End()
        {
            _logger.Info("Application End");
        }
    }
}
