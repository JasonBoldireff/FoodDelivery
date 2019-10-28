using Microsoft.Extensions.Configuration;
using System;
using DAL;
using System.IO;

namespace FoodDelivery
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
        static void Main(string[] args)
        {
            var restaurantsDb = new RestaurantsDB(Configuration);

            var restaurants = restaurantsDb.GetRestaurants();
            
            //get all Restaurants
            Console.WriteLine("-- GET ALL RRESTAURANTS--");
            foreach (var hotel in restaurants)
            {
                Console.WriteLine(hotel.ToString());
            }
            /*
            //get one Restaurant
            Console.WriteLine("-- GET ONE HOTEL--");
            var rest2 = restaurantsDb.GetRestaurant(2);
            Console.WriteLine(rest2.Name);
            

            //add Restaurant
            Console.WriteLine("-- ADD NEW HOTEL--");
            var newRestaurant = restaurantsDb.AddRestaurant(new Restaurant { Name = "Alpenblick", CityCode = 3704});
            Console.WriteLine($"ID: {newRestaurant.IdRestaurant} Name: {newRestaurant.Name}");
            

            restaurants = restaurantsDb.GetRestaurants();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"ID: {restaurant.IdRestaurant} Name: {restaurant.Name}");
            }
            /*
            //update Restaurant
            Console.WriteLine("-- Update HOTEL--");
           newRestaurant.Name = "Alpenperle";
            var updateResturant = restaurantsDb.UpdateRestaurant(newRestaurant);

            restaurants = restaurantsDb.GetRestaurants();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"ID: {restaurant.IdRestaurant} Name: {restaurant.Name}");
            }
           
            
            //delete Restaurant
            Console.WriteLine("-- Delete HOTEL--");
            int id = 8;
            var deleteHotel = restaurantsDb.DeleteRestaurant(id);
            
            restaurants = restaurantsDb.GetRestaurants();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"ID: {restaurant.IdRestaurant} Name: {restaurant.Name}");
            }*/
        }
    }
}
