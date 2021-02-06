using ProjectDatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Testdal
{
    public class DalImp:DalInter
    {

        TourismWebsiteDBEntities dbcon;
        public DalImp()
        {

        }

        public User Userid(int id)
        {
            User user = new User();
            using(dbcon = new TourismWebsiteDBEntities())
            {
                user = dbcon.Users.Find(id);
            }

            return user;
        }
        public bool CreateBlog(BlogSpace UserBlog)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.BlogSpaces.Add(UserBlog);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }


            return status;
        }

        public User FindUser(User user) {
            
            User userExe = new User();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                user.Password = GetHash(user.Password);
                 userExe = dbcon.Users.Where(x => x.UserName == user.UserName && x.Password.Length == user.Password.Length && x.Password == user.Password ).FirstOrDefault();
             //   int changes = dbcon.SaveChanges();
          
            }


            return userExe;
        }
        public bool CreateUser(User obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                obj.Password = GetHash(obj.Password);
                dbcon.Users.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }

            return status;
        }

        public bool DeleteBlog(int id)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var Todel = dbcon.BlogSpaces.Find(id);
                dbcon.BlogSpaces.Remove(Todel);
                int change = dbcon.SaveChanges();
                if (change > 0)
                    status = true;
            }
            return status;

        }

        public Hotel DeleteHotel(int id)
        {
            //bool status = false;
            Hotel hotel = new Hotel();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                hotel = dbcon.Hotels.Find(id);
                dbcon.Hotels.Remove(hotel);
                int change = dbcon.SaveChanges();



            }
            return hotel;
        }

        public bool DeleteLocation(int id)
        {
            bool status = false;
            var Todel = dbcon.Locations.Find(id);
            dbcon.Locations.Remove(Todel);
            int change = dbcon.SaveChanges();

            if (change > 0)
                status = true;
            return status;
        }

        public bool DeletePlace(int id)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var Todel = dbcon.TouristPlaces.Find(id);
                dbcon.TouristPlaces.Remove(Todel);
                int change = dbcon.SaveChanges();

                if (change > 0)
                    status = true;
            }

            return status;
        }

        public List<Package> GetallPackages()
        {
            List<Package> packages = new List<Package>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                packages = dbcon.Packages.ToList();

            }

            return packages;
        }

        public bool Addpackages(Package pack)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                
                dbcon.Packages.Add(pack);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }

            return status;

        }
        public bool Updatepacakges(Package pack)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var getobj = dbcon.Packages.Where(s => s.PackageId == pack.PackageId).First();
            
                getobj.PlaceName = pack.PlaceName;
                getobj.NoOfDays = pack.NoOfDays;
                getobj.NoOfNights = pack.NoOfNights;
                getobj.NoOfPerson = pack.NoOfPerson;
                getobj.Price = pack.Price;
                getobj.Image = pack.Image;
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            return status;
        }
        public Package Deletepackages(int id)
        {
            Package pack = new Package();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                 pack = dbcon.Packages.Find(id);
                dbcon.Packages.Remove(pack);
                int change = dbcon.SaveChanges();

            }

            return pack;

        }
        public Package Findpack(int id)
        {
            Package pack = new Package();
            using(dbcon = new TourismWebsiteDBEntities())
            {
                pack = dbcon.Packages.Find(id);
            }
            return pack;
        }
        public bool DeleteReview(int id)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var Todel = dbcon.UserReviews.Find(id);
                dbcon.UserReviews.Remove(Todel);
                int change = dbcon.SaveChanges();
                if (change > 0)
                    status = true;
            }

            return status;
        }

        public bool DeleteUser(int id)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var Todel = dbcon.Users.Find(id);
                dbcon.Users.Remove(Todel);
                int change = dbcon.SaveChanges();
                if (change > 0)
                    status = true;
            }

            return status;
        }

        public List<BlogSpace> GetAllBlogs()
        {
            List<BlogSpace> Bloglist = new List<BlogSpace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                Bloglist = dbcon.BlogSpaces.ToList();

            }

            return Bloglist;
        }

        public List<Hotel> GetAllHotel()
        {

            List<Hotel> Hotellist = new List<Hotel>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                Hotellist = dbcon.Hotels.ToList();

            }

            return Hotellist;
        }

        public List<Location> GetAllLocations()
        {
            List<Location> LocList = new List<Location>();
            using (dbcon = new TourismWebsiteDBEntities())
            {

                LocList = dbcon.Locations.ToList();



            }

            return LocList;
        }

        public List<TouristPlace> GetAllPlace()
        {
            List<TouristPlace> TPlaceList = new List<TouristPlace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                TPlaceList = dbcon.TouristPlaces.ToList();

            }

            return TPlaceList;
        }

        public List<User> GetAllUsers()
        {
            List<User> UserList = new List<User>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                UserList = dbcon.Users.ToList();

            }

            return UserList;
        }

        public List<BlogSpace> GetBlogs(string title)
        {
            List<BlogSpace> BlogList = new List<BlogSpace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                BlogList = dbcon.BlogSpaces.Where(x => x.Title == title).ToList();


            }

            return BlogList;
        }

        public List<BlogSpace> GetBlogsByLocation(string location)
        {
            List<BlogSpace> BlogList = new List<BlogSpace>();
           // using (dbcon = new TourismWebsiteDBEntities())
            //{
               // BlogList = dbcon.BlogSpaces.Where(x => (string)x.LocationName == location).ToList();

            //}

            return BlogList;
        }


        /*        public List<double> GetCoordinates(string location)
                {
                    List<double> coords = new List<double>();
                    using (dbcon = new TourismWebsiteDBEntities())
                    {
                        var req = dbcon.Locations.Where(x => x.LocationName == location).FirstOrDefault();
                        coords.Add(req.Latitude);
                        coords.Add(req.Longitude);

                    }
                    return coords;
                }

        */
        public Location GetCoordinates(string location)
        {
            Location coords = new Location();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                coords = dbcon.Locations.Where(x => x.LocationName == location).FirstOrDefault();


            }

            return coords;
        }

        public Hotel GetHotelPrice(int id)
        {
            Hotel HotelPrice = null;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                HotelPrice = (Hotel)dbcon.Hotels.Where(x => x.Id == id).First();

            }

            return HotelPrice;

        }

        public List<Hotel> GetHotelsByLocation(int Locationid)
        {
            List<Hotel> HotelList = new List<Hotel>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                HotelList = dbcon.Hotels.Where(x => (int)x.LocationId == Locationid).ToList();

            }

            return HotelList;
        }

        public List<Hotel> GetHotelsByName(string Name)
        {
            List<Hotel> HotelsListByName = new List<Hotel>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                HotelsListByName = dbcon.Hotels.Where(x => (string)x.HotelName == Name).ToList();

            }

            return HotelsListByName;
        }

        public List<TouristPlace> GetPlacesByLocation(int Locationid)
        {
            List<TouristPlace> PlacesListbyLocation = new List<TouristPlace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                PlacesListbyLocation = dbcon.TouristPlaces.Where(x => (int)x.LocationId == Locationid).ToList();

            }

            return PlacesListbyLocation;
        }

        public List<TouristPlace> GetPlacesByName(string Name)
        {
            List<TouristPlace> PlacesListbyName = new List<TouristPlace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                PlacesListbyName = dbcon.TouristPlaces.Where(x => (string)x.PlaceName == Name).ToList();

            }

            return PlacesListbyName;
        }

        public List<TouristPlace> GetPlacesByRating(int Rating)
        {
            List<TouristPlace> PlacesByRating = new List<TouristPlace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                PlacesByRating = dbcon.TouristPlaces.Where(x => x.Ratings == Rating).ToList();

            }

            return PlacesByRating;
        }

        public List<UserReview> GetUserReviews()
        {

            List<UserReview> UList = new List<UserReview>();

            return UList;
        }

        public bool InsertHotel(Hotel obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.Hotels.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }

            return status;
        }

        public async Task<bool> InsertLocation(Location obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.Locations.Add(obj);
                int changes = await dbcon.SaveChangesAsync();
                if (changes > 0)
                {
                    status = true;
                }
            }

            return status;
        }

        public bool InsertTPlace(TouristPlace obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.TouristPlaces.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }

            return status;
        }

        public bool RatingAPlace(UserReview Review)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.UserReviews.Add(Review);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }

            return status;
        }

        public bool UpdateBlog(BlogSpace obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.BlogSpaces.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }

            return status;
        }

        public Hotel GetHotel(int id)
        {
            Hotel hotel = new Hotel();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                hotel = dbcon.Hotels.Find(id);
            }

            return hotel;
        }
        public bool UpdateHotel(Hotel obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var getobj = dbcon.Hotels.Where(s => s.Id == obj.Id).First();
                if (obj.hotelImage != null)
                {
                    getobj.hotelImage = obj.hotelImage;
                }
                getobj.HotelName = obj.HotelName;
                getobj.Hoteltype = obj.Hoteltype;
                getobj.Price = obj.Price;
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool UpdateLocation(Location obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.Locations.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }

            return status;
        }

        public bool UpdatePlace(TouristPlace obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var uobj = dbcon.TouristPlaces.Where(x => x.Id == obj.Id).First();
                uobj.PlaceName = obj.PlaceName;
                uobj.Ratings = obj.Ratings;

                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool UpdateUser(User obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var uobj = dbcon.Users.Where(x => x.UserId == obj.UserId).First();
                uobj.UserName = obj.UserName;
                uobj.Isactive = obj.Isactive;
                uobj.ContactNumber = obj.ContactNumber;
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            return status;
        }
      

        public bool InsertFlight(Flight obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.Flights.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            return status;
        }


        public bool DeleteFlight(int F_Id)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var Todel = dbcon.Flights.Find(F_Id);
                dbcon.Flights.Remove(Todel);
                int change = dbcon.SaveChanges();
                if (change > 0)
                    status = true;
            }
            return status;
        }











        public List<Flight> GetAllFlights()
        {
            List<Flight> Flightlist = new List<Flight>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                Flightlist = dbcon.Flights.ToList();

            }

            return Flightlist;
        }













        public List<Flight> GetFlightbyDate(string Departure_Date)
        {
            List<Flight> FlightList = new List<Flight>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                FlightList = dbcon.Flights.Where(x => x.Departure_Date == Departure_Date).ToList();

            }

            return FlightList;
        }

        public List<Flight> GetFlightbyTime(string Departure_Time)
        {
            List<Flight> FlightList = new List<Flight>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                FlightList = dbcon.Flights.Where(x => x.Departure_Time == Departure_Time).ToList();

            }

            return FlightList;
        }

        public Flight GetFlightName(string F_Name)
        {
            Flight flight = null;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                flight = (Flight)dbcon.Flights.Where(x => x.F_Name == F_Name).First();

            }

            return flight;
        }

        public List<Flight> GetFlightsbyLocation(int LocationId)
        {
            List<Flight> FlightList = new List<Flight>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                FlightList = dbcon.Flights.Where(x => (int)x.LocationId == LocationId).ToList();

            }

            return FlightList;
        }














        public bool UpdateFlight(Flight obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var flight = dbcon.Flights.Find(obj.F_Id);
                flight.F_Name = obj.F_Name;
                flight.Start_From = obj.Start_From;
                flight.Destination = obj.Destination;
                flight.Departure_Date = obj.Departure_Date;
                flight.Departure_Time = obj.Departure_Time;
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            return status;
        }



        public Flight GetFlightName(int F_Id)
        {
            Flight F_Name = new Flight();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                F_Name = (Flight)dbcon.Flights.Where(x => x.F_Id == F_Id).First();

            }

            return F_Name;
        }




        public string GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
            {
                byte[] bb = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bb.Length; i++)
                {
                    builder.Append(bb[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }




    }
}
