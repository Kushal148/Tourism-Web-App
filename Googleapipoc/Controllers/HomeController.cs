using Googleapipoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Googleapipoc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Coords co)
        {
            Coords s = new Coords { lattitude = co.lattitude, longitude = co.longitude };
            return View(s);
        }
     
    }
}