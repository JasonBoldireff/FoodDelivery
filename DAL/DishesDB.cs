using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DishesDB : IDishesDB
    {
        public IConfiguration Configuration { get; }
        public DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Dish> GetDishes() //if we know the query returns multiple results use while loop
        {
            List<Dish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dish>();

                            Dish dish = new Dish();

                            dish.DishID= (int)dr["DishID"];
                            dish.RestaurantID = (int)dr["RestaurantID"];
                            dish.Name = (String)dr["Name"];
                            dish.Price = (long)dr["Price"];
                           
                            results.Add(dish);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public Dish GetDish(int id) //when we know the return is only one result we use an IF-loop as decision maker
        {
            Dish dish = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dishes where DishID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dish = new Dish();

                            dish.DishID = (int)dr["DishID"];
                            dish.RestaurantID = (int)dr["RestaurantID"];
                            dish.Name = (String)dr["Name"];
                            dish.Price = (long)dr["Price"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return dish;
        }

        public Dish AddDish(Dish dish)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Dishes(DishID,RestaurantID , Name, Price)" +
                                               "values (@id, @restId, @name, @price); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", dish.DishID);
                    cmd.Parameters.AddWithValue("@restId", dish.RestaurantID);
                    cmd.Parameters.AddWithValue("@name", dish.Name);
                    cmd.Parameters.AddWithValue("@price", dish.Price);

                    cn.Open();

                    dish.DishID = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        public int UpdateDish(Dish dish)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update Dishes SET Name = @name where DishID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", dish.DishID);
                    cmd.Parameters.AddWithValue("@name", dish.Name);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public int DeleteDish(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Dishes WHERE DishID = @id";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
