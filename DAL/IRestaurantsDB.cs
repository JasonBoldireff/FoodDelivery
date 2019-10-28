using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IRestaurantsDB
    {
        IConfiguration Configuration { get; }

        List<Restaurant> GetRestaurants();

        Restaurant GetRestaurant(int id);

        Restaurant AddRestaurant(Restaurant restaurant);

        int UpdateRestaurant(Restaurant restaurant);

        int DeleteRestaurant(int id);
    }
}
