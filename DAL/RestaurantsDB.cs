using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class RestaurantsDB : IRestaurantsDB
    {
        public IConfiguration Configuration { get; }
        public RestaurantsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Restaurant> GetRestaurants() //if we know the query returns multiple results use while loop
        {
            List<Restaurant> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurants";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.IdRestaurant = (int)dr["RestaurantID"];
                            restaurant.CityCode = (int)dr["CityCode"];
                            restaurant.Name = (String)dr["Name"];
                            //restaurant.Status = (Bit)dr["Status"]; Problem with the Unit.. 

                            results.Add(restaurant);
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

        public Restaurant GetRestaurant(int id) //when we know the return is only one result we use an IF-loop as decision maker
        {
            Restaurant restaurant = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurants where RestaurantID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurant = new Restaurant();

                            restaurant.IdRestaurant = (int)dr["RestaurantID"];
                            restaurant.CityCode = (int)dr["CityCode"];
                            restaurant.Name = (String)dr["Name"];
                            //restaurant.Status = (Boolean)dr["Status"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return restaurant;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Restaurants(CityCode, Name)" +
                                               "values (@code, @name); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@code", restaurant.CityCode);
                    cmd.Parameters.AddWithValue("@name", restaurant.Name);

                    cn.Open();

                    restaurant.IdRestaurant = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update Restaurants SET CityCode = @code, Name = @name where RestaurantID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", restaurant.IdRestaurant);
                    cmd.Parameters.AddWithValue("@code", restaurant.CityCode);
                    cmd.Parameters.AddWithValue("@name", restaurant.Name);

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

        public int DeleteRestaurant(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Restaurants WHERE RestaurantID = @id";

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
