using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class RestaurantsManager
    {
        public RestaurantsDB RestaurantDB { get; }

        public RestaurantsManager(IConfiguration configuration)
        {
            RestaurantDB = new RestaurantsDB(configuration);
        }

        public List<Restaurant> GetHotels()
        {
            return RestaurantDB.GetRestaurants();
        }

        public Restaurant GetHotel(int id)
        {
            return RestaurantDB.GetRestaurant(id);
        }

        public Restaurant AddRestaurant(Restaurant hotel)
        {
            return RestaurantDB.AddRestaurant(hotel);
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDB.UpdateRestaurant(restaurant);
        }

        public int DeleteHotel(int id)
        {
            return RestaurantDB.DeleteRestaurant(id);
        }
    }
}

