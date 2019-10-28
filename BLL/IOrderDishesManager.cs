using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public interface IOrderDishesManager
    {
        IOrderDishesDB OrderDishDB { get; }
        List<OrderDish> GetOrderDishes();

        OrderDish GetOrderDish(int id);

        OrderDish AddOrderDish(OrderDish orderDish);

        int UpdateOrderDish(OrderDish orderDish);

        int DeleteOrderDish(int id);
    }
}
