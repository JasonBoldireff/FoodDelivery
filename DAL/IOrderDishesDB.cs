using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IOrderDishesDB
    {
        IConfiguration Configuration { get; }

        List<OrderDish> GetOrderDishes();

        OrderDish GetOrderDish(int id);

        OrderDish AddOrderDish(OrderDish orderDish);

        int UpdateOrderDish(OrderDish orderDish);

        int DeleteOrderDish(int id);
    }
}
