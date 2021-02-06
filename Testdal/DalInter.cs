using ProjectDatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testdal
{
    public interface DalInter
    {
        //location
        //user
        //location
        //userss
        Location GetCoordinates(string location);

        //admin
        Task<bool> InsertLocation(Location obj);
        bool UpdateLocation(Location obj);
        bool DeleteLocation(int id);
        List<Location> GetAllLocations();

        //Blogspace
        //user
        List<BlogSpace> GetBlogs(String title);
        List<BlogSpace> GetBlogsByLocation(String Location);
        bool CreateBlog(BlogSpace UserBlog);
        bool UpdateBlog(BlogSpace obj);

        //admin
        bool DeleteBlog(int id);
        List<BlogSpace> GetAllBlogs();

        //Hotels:
        //User
        List<Hotel> GetHotelsByName(string Name);
        // List<Hotels> GetHotelsByLocation(string Location);

        List<Hotel> GetHotelsByLocation(int Locationid);
        //double GetHotelPrice(string Name);
        Hotel GetHotelPrice(int id);


        //admin
        bool InsertHotel(Hotel obj);
        bool UpdateHotel(Hotel obj);
        Hotel DeleteHotel(int id);

        Hotel GetHotel(int id);
        List<Hotel> GetAllHotel();

        //TouristPlaces:
        //User
        List<TouristPlace> GetPlacesByLocation(int Locationid);
        List<TouristPlace> GetPlacesByName(string Name);
        List<TouristPlace> GetPlacesByRating(int Rating);
        //Admin
        bool InsertTPlace(TouristPlace obj);
        bool UpdatePlace(TouristPlace obj);
        bool DeletePlace(int id);
        List<TouristPlace> GetAllPlace();

        //Usertable
        //user
        bool CreateUser(User obj);
        User FindUser(User user);

        User Userid(int id);
        //admin
        bool UpdateUser(User obj);
        bool DeleteUser(int id);
        List<User> GetAllUsers();

        //User Review
        //user
        bool RatingAPlace(UserReview Review);
        //admin
        bool DeleteReview(int id);
        List<UserReview> GetUserReviews();

        //Flights
        Flight GetFlightName(int F_Id);
        List<Flight> GetAllFlights();

        List<Flight> GetFlightsbyLocation(int LocationId);

        List<Flight> GetFlightbyDate(string Departure_Date);

        List<Flight> GetFlightbyTime(string Departure_Time);

        bool InsertFlight(Flight obj);
        bool UpdateFlight(Flight obj);
        bool DeleteFlight(int F_Id);


          string GetHash(string inputString);


        //Packages
        List<Package> GetallPackages();

        bool Addpackages(Package pack);
        bool Updatepacakges(Package pack);

        Package Deletepackages(int id);

        Package Findpack(int id);
         
    }
}
