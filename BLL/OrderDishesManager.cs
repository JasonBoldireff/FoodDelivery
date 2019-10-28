using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class OrderDishesManager
    {
        public OrderDishesDB OrderDishDB { get; }

        public OrderDishesDB (IConfiguration configuration)
        {
            OrderDishDB = new OrderDishesDB(configuration);
        }

        public List<OrderDish> GetOrderDishes()
        {
            return OrderDishDB.GetOrderDishes();
        }

        public OrderDish GetOrderDish(int id)
        {
            return OrderDishDB.GetOrderDish(id);
        }

        public OrderDish AddOrderDish(OrderDish dish)
        {
            return OrderDishDB.AddOrderDish(dish);
        }

        public int UpdateOrderDish(OrderDish dish)
        {
            return OrderDishDB.UpdateOrderDish(dish);
        }

        public int DeleteOrderDish(int id)
        {
            return OrderDishDB.DeleteOrderDish(id);
        }
    }
}
