using OnlineShop2.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using OnlineShop2.Common;

namespace OnlineShop2.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDao();
                var result = dao.Login(model.UserName,Encryptor.MD5Hash(model.Password) );

                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstains.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Home");
                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "Account not exists!");
                }else if (result == -1)
                {
                    ModelState.AddModelError("", "Account is blocked!");
                }else if (result == -2)
                {
                    ModelState.AddModelError("", "Password is incorrect!");
                }
                else
                {
                    ModelState.AddModelError("", "Login fail!");
                }
            }

            return View("Index");
        }
    }
}