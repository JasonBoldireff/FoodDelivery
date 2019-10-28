using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class OrdersDB : IOrdersDB
    {
        public IConfiguration Configuration { get; }
        public OrdersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Order> GetOrders() //if we know the query returns multiple results use while loop
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Orders";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.OrderID= (int)dr["OrderID"];
                            order.OrderDishID = (int)dr["OrderDishID"];
                            order.UserID = (int)dr["UserID"];
                            order.OrderTime = (String)dr["OrderTime"];
                            order.DeliveryTime = (String)dr["DeliveryTime"];
                            order.PriceTotal = (long)dr["PriceTotal"];

                            results.Add(order);
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

        public Order GetOrder(int id) //when we know the return is only one result we use an IF-loop as decision maker
        {
            Order order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Orders where OrderID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Order();

                            order.OrderID = (int)dr["OrderID"];
                            order.OrderDishID = (int)dr["OrderDishID"];
                            order.UserID = (int)dr["UserID"];
                            order.OrderTime = (String)dr["OrderTime"];
                            order.DeliveryTime = (String)dr["DeliveryTime"];
                            order.PriceTotal = (long)dr["PriceTotal"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return order;
        }

        public Order AddOrder(Order order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Orders(OrderID,OrderDishID , UserID, OrderTime, DeliveryTime, PriceTotal)" +
                                               "values (@id, @oderDishId, @userId, @orderTime, @deliveryTime, @priceTotal); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", order.OrderID);
                    cmd.Parameters.AddWithValue("@orderDishId", order.OrderDishID);
                    cmd.Parameters.AddWithValue("@userId", order.UserID);
                    cmd.Parameters.AddWithValue("@orderTime", order.OrderTime);
                    cmd.Parameters.AddWithValue("@deliveryTime", order.DeliveryTime);
                    cmd.Parameters.AddWithValue("@priceTotal", order.PriceTotal);


                    cn.Open();

                    order.OrderID = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public int UpdateOrder(Order order)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update Orders SET OrderTime = @orderTime where OrdeID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", order.OrderID);
                    cmd.Parameters.AddWithValue("@orderTime", order.OrderTime);

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

        public int DeleteOrder(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Orders WHERE OrderID = @id";

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
