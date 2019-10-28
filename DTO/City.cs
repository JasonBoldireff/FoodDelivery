using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class City
    {
        public int CityCode { get; set; }
        public String Name { get; set; }


        public override string ToString()
        {
            return $"{CityCode}|{Name}";
        }
    }
}
