using ProjectDatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismMVCWebsite.Controllers
{
   [Authorize]
    public class UserController : Controller
    {
        // GET: User
        private TourismWebsiteDBEntities db = new TourismWebsiteDBEntities();
        public ActionResult Index()
        {
            
            return View(db.Packages.ToList());
        }

        public ActionResult ViewDetails(int? id)
        {
           
            var packages = db.Packages.Find(id);
            Session["imgPath"] = packages.Image;
            if (packages == null)
            {
                return HttpNotFound();
            }

            return View(packages);
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

        [HttpPost]
        public ActionResult BookPackage(string FirstName, string LastName, string Address, string PostCode, string City, int PhoneNumber, string EmailId, int PackageId, int Adults, int Total)
        {
            return View();
        }

    }
}