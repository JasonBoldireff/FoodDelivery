using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IRestaurantsManager
    {
        IRestaurantsDB RestaurantDB { get; }

        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);
        Restaurant AddRestaurant(Restaurant hotel);
        Restaurant UpdateRestaurant(Restaurant hotel);
        int DeleteRestaurant(int id);

    }
}
