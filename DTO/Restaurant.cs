using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Restaurant
    {
        public int IdRestaurant { get; set; }
        public int CityCode { get; set; }
        public String Name { get; set; }
        //public Boolean Status { get; set; }


        public override string ToString()
        {
            return $"{IdRestaurant}|{Name}|{CityCode}";
        }
    }
}
