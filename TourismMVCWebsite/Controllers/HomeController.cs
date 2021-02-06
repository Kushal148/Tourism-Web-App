using ProjectDatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismMVCWebsite.Controllers
{
    public class HomeController : Controller
    {
        private TourismWebsiteDBEntities db = new TourismWebsiteDBEntities();
        public ActionResult Index()
        {
            return View(db.Packages.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Destination()
        {
            return View();
        }

        public ActionResult Destination2()
        {
            return View();
        }
        public ActionResult Destination3()
        {
            return View();
        }

        public ActionResult Destination4()
        {
            return View();
        }

        public ActionResult Packages()
        {

            return View(db.Packages.ToList());
        }

        public ActionResult Booking(int? id)
        {
            var packages = db.Packages.Find(id);
            Session["imgPath"] = packages.Image;
            if (packages == null)
            {
                return HttpNotFound();
            }

            return View(packages);
        }
    }
}