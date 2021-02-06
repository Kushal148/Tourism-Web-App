
using ProjectDatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testdal;
namespace TourismMVCWebsite.Controllers
{
    public class FlightController : Controller
    {
        // GET: Flight

        private readonly DalInter con;
        public FlightController()
        {
            con = new DalImp();
        }
        public ActionResult Index(string Id)
        {
            if (Id == null)
            {
                Id = "";
            }
            IEnumerable<Flight> Lflights = con.GetAllFlights();


            if (!string.IsNullOrEmpty(Id) && Id != "All")
            {
                Lflights = Lflights.Where(p => p.F_Name.ToLower() == Id.ToLower());
            }
            return View(Lflights);

        }

        public ActionResult UserIndex(string Id)
        {
            if (Id == null)
            {
                Id = "";
            }
            IEnumerable<Flight> Lflights = con.GetAllFlights();


            if (!string.IsNullOrEmpty(Id) && Id != "All")
            {
                Lflights = Lflights.Where(p => p.F_Name.ToLower() == Id.ToLower());
            }
            return View(Lflights);

        }
    }
}