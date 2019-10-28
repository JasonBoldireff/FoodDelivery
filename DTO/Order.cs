using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order
    {
        public int OrderID { get; set; }
        public int OrderDishID { get; set; }
        public int UserID { get; set; }
        public String OrderTime { get; set; }
        public String DeliveryTime { get; set; }
        // public Boolean Status { get; set; }
        public long PriceTotal { get; set; }


        public override string ToString()
        {
            return $"{OrderID}|{OrderDishID}|{OrderTime}|{OrderTime}|{PriceTotal}";
        }
    }
}
