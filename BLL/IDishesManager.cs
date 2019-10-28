using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public interface IDishesManager
    {
        IDishesDB DishDB { get; }
        List<Dish> GetDishes();

        Dish GetDish(int id);

        Dish AddDish(Dish dish);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);
    }
}
