using ProjectDatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TourismMVCWebsite.Models;
using Testdal;

namespace TourismMVCWebsite.Controllers
{
    public class AccountController : Controller
    {
        //TourismWebsiteDBEntities db = new TourismWebsiteDBEntities();
        // GET: Account
        private readonly DalInter con;
        public AccountController()
        {
            con = new DalImp();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {

            User result = con.FindUser(new User { UserName = model.UserName, Password = model.Password});
                if (result != null)
                {
                    Session["Id"] = result.UserId;
                    FormsAuthentication.SetAuthCookie(result.UserName, false);
                    if (result.Isadmin == 1)
                    {
                        return RedirectToAction("Front", "Admin");
                    }
                    if (result.Isadmin == 2)
                    {
                        return RedirectToAction("Index", "User");
                    }

                }

                else
                {
                    ModelState.AddModelError("", "invalid username and password");
                }
            
           

            return View(model);
        }


        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User model)
        {
            con.CreateUser(model);
            ViewBag.SuccessMethod = "Registration Successfull";
            return RedirectToAction("Login");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }   
}