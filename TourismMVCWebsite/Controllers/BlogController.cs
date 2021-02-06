using ProjectDatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismMVCWebsite.Controllers
{
    public class BlogController : Controller
    {
        private TourismWebsiteDBEntities nd = new TourismWebsiteDBEntities();
        // GET: Blog
     
        // GET: Blog
        public ActionResult Blogs()
        {
            var blogdetails = nd.BlogSpace1.ToList().OrderByDescending(x => x.Id);
            return View(blogdetails);
        }
        public ActionResult UserBlogs()
        {
            var blogdetails = nd.BlogSpace1.ToList().OrderByDescending(x => x.Id);
            return View(blogdetails);
        }
        public ActionResult BlogDesc()
        {
            var blogdesc = nd.BlogSpace1.ToList().OrderByDescending(x => x.Id);
            return View(blogdesc);
        }

        public ActionResult Uploadblog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uploadblog(BlogSpace1 bg)
        {

            nd.BlogSpace1.Add(bg);
            nd.SaveChanges();
            ViewBag.message = "Blog details added successfully";
            return View();
        }

        public ActionResult Destination()
        {
            var destinationarticle = nd.BlogSpace1.Where(x => x.Category == "Destination");
            return View(destinationarticle);
        }
        public ActionResult Travel_Experience()
        {
            var travelarticle = nd.BlogSpace1.Where(x => x.Category == "Travel Experience");
            return View(travelarticle);

        }
        public ActionResult Miscellaneous()
        {
            var miscarticle = nd.BlogSpace1.Where(x => x.Category == "Miscellaneous");
            return View(miscarticle);

        }

    }
}