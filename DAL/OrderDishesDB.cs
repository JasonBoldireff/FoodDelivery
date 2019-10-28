using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class OrderDishesDB : IOrderDishesDB
    {
        public IConfiguration Configuration { get; }
        public OrderDishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<OrderDish> GetOrderDishes() //if we know the query returns multiple results use while loop
        {
            List<OrderDish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM OrderDishes";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDish>();

                            OrderDish dish = new OrderDish();

                            dish.OrderDishID= (int)dr["OrderDishID"];
                            dish.DishID = (int)dr["DishID"];
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

        public OrderDish GetOrderDish(int id) //when we know the return is only one result we use an IF-loop as decision maker
        {
            OrderDish dish = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM OrderDishes where OrderDishID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dish = new OrderDish();

                            dish.OrderDishID = (int)dr["OrderDishID"];
                            dish.DishID = (int)dr["DishID"];
                            dish.Quantity = (int)dr["Quantity"];
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

        public OrderDish AddOrderDish(OrderDish dish)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into OrderDishes(OrderDishID,DishID , Quantity, Price)" +
                                               "values (@id, @dishId, @quantity, @price); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", dish.OrderDishID);
                    cmd.Parameters.AddWithValue("@restId", dish.DishID);
                    cmd.Parameters.AddWithValue("@quantity", dish.Quantity);
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

        public int UpdateOrderDish(OrderDish dish)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update Dishes SET Quantity = @quantity where OrderDishID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", dish.DishID);
                    cmd.Parameters.AddWithValue("@quantity", dish.Quantity);

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

        public int DeleteOrderDish(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM OrderDishes WHERE OrderDishID = @id";

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
