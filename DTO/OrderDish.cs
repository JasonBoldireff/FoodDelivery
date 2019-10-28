using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderDish
    {
        public int OrderDishID { get; set; }

        public int DishID { get; set; }
        public int Quantity { get; set; }
       // public Boolean Status { get; set; }

        public long Price { get; set; }


        public override string ToString()
        {
            return $"{OrderDishID}|{DishID}|{Quantity}|{Price}";
        }
    }
}
