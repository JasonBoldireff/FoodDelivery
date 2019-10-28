using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dish
    {
        public int DishID { get; set; }

        public int RestaurantID { get; set; }

        public String Name { get; set; }
        //public Boolean Status { get; set; }

        public long Price { get; set; }

        public override string ToString()
        {
            return $"{DishID}|{RestaurantID}|{Name}|{Price}";
        }
    }
}
