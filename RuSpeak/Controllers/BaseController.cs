using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using RuSpeak.Global.Auth;
using RuSpeak.Infrastructure.Mappers;
using RuSpeak.Models.Auth;

namespace RuSpeak.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IMapper ModelMapper { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }
        public User CurrentUser
        {
            get
            {
                return ((UserIndentity)Auth.CurrentUser.Identity).User;
            }
        }
    }
}