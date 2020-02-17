using Model.Dao;
using Model.EF;
using OnlineShop2.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop2.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    var passwordEncrytorMD5 = Encryptor.MD5Hash(user.Password);
                    user.Password = passwordEncrytorMD5;
                    long id = dao.Insert(user);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Add user successfull!");
                    }
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }





            return View("Index");








        }
    }
}