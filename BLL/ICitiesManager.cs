using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICitiesManager
    {
        ICitiesDB CityDB{ get; }

        List<City> GetCities();
        City GetCities(int id);
        City AddCity(City city);
        City UpdateCity(City city);
        int DeleteCity(int id);
    }
}
