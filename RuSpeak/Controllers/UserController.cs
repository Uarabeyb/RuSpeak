using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RuSpeak.DAL.Abstract;
using RuSpeak.Models;
using RuSpeak.Models.Auth;

namespace RuSpeak.Controllers
{
    public class UserController : BaseController
    {
        private IUserRepository repository;

        public UserController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        public ActionResult List()
        {
            return View(repository.Users);
        }

        #region Register

        [HttpGet]
        public ActionResult Register()
        {
            var registerInfo = new RegisterInfo();
            return View(registerInfo);
        }

        [HttpPost]
        public ActionResult Register(RegisterInfo registerInfo)
        {
            if (ModelState.IsValid)
            {
                var emails = repository.Users.Select(x => x.Email);
                if (emails.Any(x => x.Equals(registerInfo.Email)))
                {
                    ModelState["Email"].Errors.Add("Указанная почта уже занята");
                }
                else
                {
                    var user = (User)ModelMapper.Map(registerInfo, typeof(RegisterInfo), typeof(User));
                    repository.SaveUser(user);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(registerInfo);
        }

        #endregion

        #region EditProfile

        [Authorize]
        [HttpGet]
        public ActionResult EditProfile(int userId)
        {
            var user = repository.GetUser(userId);
            var userProfile = new UserProfile { Email = user.Email, UserName = user.UserName, UserId = CurrentUser.UserId };
            return View(userProfile);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProfile(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                var user = repository.GetUser(userProfile.UserId);
                user.UserName = userProfile.UserName;
                user.Email = userProfile.Email;
                repository.SaveUser(user);
                return RedirectToAction("Index", "Home");
            }

            return View(userProfile);
        }

        #endregion

        #region Delete User

        [Authorize]
        public ActionResult Delete(int userId)
        {
            repository.DeleteUser(userId);
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Login

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Login(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add("Логин или пароль не верный");
            }
            return View(loginView);
        }

        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult AjaxLogin()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult AjaxLogin(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return View("_Ok");
                }
                ModelState["Password"].Errors.Add("Пароли не совпадают");
            }
            return View(loginView);
        }

        #endregion
    }
}