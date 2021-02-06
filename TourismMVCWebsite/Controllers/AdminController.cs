using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectDatabaseLib;
using Testdal;

namespace TourismMVCWebsite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //private TourismWebsiteDBEntities db = new TourismWebsiteDBEntities();
        private readonly DalInter con;// kushal
      

        public AdminController()
        {
            con = new DalImp();
        

        }
        public ActionResult Front()
        {
            return View();
        }
        // GET: Admin

        public ActionResult Index()
        {
            return View(con.GetAllUsers());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = con.Userid((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,City,EmailId,ContactNumber,Isactive,Isadmin")] User user)
        {
            if (ModelState.IsValid)
            {
                con.CreateUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = con.Userid((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,City,EmailId,ContactNumber,Isactive,Isadmin")] User user)
        {
            if (ModelState.IsValid)
            {
                con.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = con.Userid((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            con.DeleteUser(id);


            return RedirectToAction("Index");
        }

     /*   protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        //pakages operations
        public ActionResult Packages()
        {
            return View(con.GetallPackages());
        }

        public ActionResult CreatePakages()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePakages(HttpPostedFileBase file, Package pkg)
        {
          
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;
            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/assets/images/"), _filename);
            pkg.Image = "~/Content/assets/images/" + _filename;
            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                bool changes = false;
                if (file.ContentLength <= 10000000)
                {
                     changes = con.Addpackages(pkg);
                }
                if (changes)
                {
                    file.SaveAs(path);
                    ViewBag.msg = "Package Added";
                    ModelState.Clear();
                }

            }
            else
            {
                ViewBag.msg = "Size is not valid";
            }
            return View();
        }


        public ActionResult EditPakages(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var packages = con.Findpack((int)id);
            Session["imgPath"] = packages.Image;
            if (packages == null)
            {
                return HttpNotFound();
            }

            return View(packages);
        }


        [HttpPost]
        public ActionResult EditPakages(HttpPostedFileBase file, Package pkg)
        {
            if (ModelState.IsValid)
            {
                if (file!= null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string extension = Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/assets/images/"), _filename);
                    pkg.Image = "~/Content/assets/images/" + _filename;
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        bool changes = false;
                        if (file.ContentLength <= 10000000)
                        {
                            changes = con.Updatepacakges(pkg);
                            string OldImgPath = Request.MapPath(Session["imgPath"].ToString());
                            if (changes)
                            {
                                file.SaveAs(path);
                                if (System.IO.File.Exists(OldImgPath))
                                {
                                    System.IO.File.Delete(OldImgPath);
                                }
                                TempData["msg"] = "Record Updated";
                            }
                        }
                        else
                        {
                            ViewBag.msg = "Size is not valid";
                        }
                    } 
                }
            }
        
            else
            {
                pkg.Image = Session["imgPath"].ToString();
                bool changes = con.Updatepacakges(pkg);
                if (changes)
                {

                    TempData["msg"] = "Package Updated";
                    return RedirectToAction("Packages");
                }
            }
            return View();
        }





        [HttpPost]
        public ActionResult DeletePakages(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == null)
            {
                return RedirectToAction("Hotels");
            }

            Package pack = con.Deletepackages((int)id);
            string Oldimage = Request.MapPath(pack.Image.ToString());

            if (System.IO.File.Exists(Oldimage))
            {
                System.IO.File.Delete(Oldimage);
            }

            return RedirectToAction("packages");
        

        }

        //public Package GetPackagename(string P_Name)
        //{
        //    Package pkg = null;

        //    pkg = (Package)db.Packages.Where(x => x.PlaceName == P_Name).First();

       
        //    return pkg;
        //}




        //Hotel 
        public ActionResult Hotels(string Id)
        {


            if (Id == null)
            {
                Id = "";
            }
            IEnumerable<Hotel> ListHotels = con.GetAllHotel();



            // IEnumerable<Product> products = repo.GetProducts();
            if (!string.IsNullOrEmpty(Id) && Id != "All")
            {
                ListHotels = ListHotels.Where(p => p.HotelName.ToLower() == Id.ToLower());
            }
            return View(ListHotels);
        }
        public ActionResult NewHotel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewHotel(HttpPostedFileBase file, Hotel obj)
        {
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;
            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/assets/images/"), _filename);
            obj.hotelImage = "~/Content/assets/images/" + _filename;
            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                bool changes = false;
                if (file.ContentLength <= 10000000)
                {
                    changes = con.InsertHotel(obj);
                }
                if (changes == true)
                {
                    file.SaveAs(path);
                    ViewBag.msg = "Hotel Added";
                    ModelState.Clear();
                }

            }
            else
            {
                ViewBag.msg = "Size is not valid";
            }
            return View();
        }

        public ActionResult HotelUpdate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = con.GetHotel((int)id);
            Session["oldImage"] = hotel.hotelImage;
            return View(hotel);
        }
        [HttpPost]
        public ActionResult HotelUpdate(HttpPostedFileBase file, Hotel obj)
        {
            
                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string extension = Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/assets/images/"), _filename);
                    obj.hotelImage = "~/Content/assets/images/" + _filename;
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        bool changes = false;
                        if (file.ContentLength <= 10000000)
                        {
                            changes = con.UpdateHotel(obj);
                            string OldImage = Request.MapPath(Session["oldImage"].ToString());
                            if (changes == true)
                            {
                                file.SaveAs(path);
                                if (OldImage != obj.hotelImage.ToString())
                                {
                                    if (System.IO.File.Exists(OldImage))
                                    {
                                        System.IO.File.Delete(OldImage);
                                    }
                                }
                                /*ViewBag.msg = "Hotel Updated";
                                ModelState.Clear();*/
                            }
                        }

                        else
                        {
                            ViewBag.msg = "Size is not valid";
                        }
                    }
                }
            
            else
            {
                obj.hotelImage = Session["oldImage"].ToString();
                if (con.UpdateHotel(obj))
                {
                    return RedirectToAction("Hotels");
                }

            }

            return View();
        }
        public ActionResult HotelDelete(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Hotels");
            }

            Hotel hotel = con.DeleteHotel((int)id);
            string Oldimage = Request.MapPath(hotel.hotelImage.ToString());

            if (System.IO.File.Exists(Oldimage))
            {
                System.IO.File.Delete(Oldimage);
            }

            return RedirectToAction("Hotels");
        }



        //Flight 
        public ActionResult NewFlight()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewFlight(Flight obj)
        {
            bool changes = false;
            changes = con.InsertFlight(obj);

            if (changes == true)
            {

                ViewBag.msg = "Flight Details Added";
                ModelState.Clear();
            }
            else
            {
                ViewBag.msg = "Flight Details Not Added";
            }
            return View();
        }

        public ActionResult FlightUpdate(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = con.GetFlightName((int)Id);

            return View(flight);
        }

        public ActionResult FlightDelete(int? F_Id)
        {

            if (F_Id == null)
            {
                return RedirectToAction("Flights");
            }

            con.DeleteFlight((int)F_Id);

            return RedirectToAction("Flights");
        }
        public ActionResult Flights(string F_Id)
        {


            if (F_Id == null)
            {
                F_Id = "";
            }
            IEnumerable<Flight> ListFlights = con.GetAllFlights();



            // IEnumerable<Product> products = repo.GetProducts();
            if (!string.IsNullOrEmpty(F_Id) && F_Id != "All")
            {
                ListFlights = ListFlights.Where(p => p.F_Name.ToLower() == F_Id.ToLower()).OrderByDescending(x => x.F_Id);
            }
            return View(ListFlights);
        }

        [HttpPost]
        public ActionResult FlightUpdate(Flight obj)
        {
          //  bool changes = false;
         //   changes = con.UpdateFlight(obj);

            if (con.UpdateFlight(obj))
            {
                return RedirectToAction("Flights");
            }



            return View();
        }
    }
}
