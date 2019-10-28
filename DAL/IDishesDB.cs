using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IDishesDB
    {
        IConfiguration Configuration { get; }

        List<Dish> GetDishes();

        Dish GetDish(int id);

        Dish AddDish(Dish dish);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);
    }
}
