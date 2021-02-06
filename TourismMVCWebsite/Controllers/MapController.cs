using ProjectDatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testdal;
using TourismMVCWebsite.Models;

namespace TourismMVCWebsite.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        private DalInter con;


        public MapController()
        {
            con = new DalImp();
        }
        public ActionResult Maps(string map)
        {
            Gmaps req = new Gmaps();
            if (map == "" || map == null)
            {
                req.lat = 12.972442;
                req.longit = 77.580643;
            }
            else
            {
                Location x = con.GetCoordinates(map);

                if (x == null)
                {
                    req.lat = 12.972442;
                    req.longit = 77.580643;
                }
                else
                {
                    req.lat = x.Longitude;
                    req.longit = x.Latitude;
                }
            }
            return View(req);
        }




        //user map
        public ActionResult UserMaps(string map)
        {
            Gmaps req = new Gmaps();
            if (map == "" || map == null)
            {
                req.lat = 12.972442;
                req.longit = 77.580643;
            }
            else
            {
                Location x = con.GetCoordinates(map);

                if (x == null)
                {
                    req.lat = 12.972442;
                    req.longit = 77.580643;
                }
                else
                {
                    req.lat = x.Longitude;
                    req.longit = x.Latitude;
                }
            }
            return View(req);
        }
    }
}