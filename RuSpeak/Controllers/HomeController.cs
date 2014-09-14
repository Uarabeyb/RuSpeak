using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RuSpeak.DAL.Abstract;

namespace RuSpeak.Controllers
{
    public class HomeController : BaseController
    {
        private IUserRepository _repository;

        public HomeController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public ActionResult Index()
        {
            var u = _repository.Users;
            return View(u);
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }

        public ActionResult About()
        {
            return View();
        }
	}
}