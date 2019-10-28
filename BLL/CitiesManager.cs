using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CitiesManager
    {
        public CitiesDB CityDB { get; }

        public CitiesManager(IConfiguration configuration)
        {
            CityDB = new CitiesDB(configuration);
        }

        public List<City> GetCities()
        {
            return CityDB.GetCities();
        }

        public City GetCity(int id)
        {
            return CityDB.GetCity(id);
        }

        public City AddCity(City city)
        {
            return CityDB.AddCity(city);
        }

        public int UpdateCity(City city)
        {
            return CityDB.UpdateCity(city);
        }

        public int DeleteCity(int id)
        {
            return CityDB.DeleteCity(id);
        }
    }
}

