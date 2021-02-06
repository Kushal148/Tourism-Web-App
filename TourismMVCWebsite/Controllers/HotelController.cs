using ProjectDatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testdal;

namespace TourismMVCWebsite.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        private readonly DalInter con;

        public HotelController()
        {
            con = new DalImp();
        }
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                id = "";
            }
            IEnumerable<Hotel> Lhotels = con.GetAllHotel();

            // IEnumerable<Product> products = repo.GetProducts();
            if (!string.IsNullOrEmpty(id) && id != "All")
            {
                Lhotels = Lhotels.Where(p => p.HotelName.ToLower() == id.ToLower());
            }
            return View(Lhotels);

        }

        public ActionResult UserIndex(string id)
        {
            if (id == null)
            {
                id = "";
            }
            IEnumerable<Hotel> Lhotels = con.GetAllHotel();

            // IEnumerable<Product> products = repo.GetProducts();
            if (!string.IsNullOrEmpty(id) && id != "All")
            {
                Lhotels = Lhotels.Where(p => p.HotelName.ToLower() == id.ToLower());
            }
            return View(Lhotels);

        }
    }
}