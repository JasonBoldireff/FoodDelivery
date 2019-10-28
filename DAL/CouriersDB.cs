using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class CouriersDB : ICouriersDB
    {
        public IConfiguration Configuration { get; }
        public CouriersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Courier> GetCouriers() //if we know the query returns multiple results use while loop
        {
            List<Courier> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Couriers";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Courier>();

                            Courier courier = new Courier();

                            courier.CityCode = (int)dr["CityCode"];
                            courier.CourierID = (int)dr["CourierID"];
                            courier.Name = (String)dr["Name"];
                            courier.Email = (String)dr["Email"];
                            courier.Password = (String)dr["Password"];

                        
                            results.Add(courier);
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

        public Courier GetCourier(int id) //when we know the return is only one result we use an IF-loop as decision maker
        {
            Courier courier = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Couriers where CourierID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            courier = new Courier();

                            courier.CourierID = (int)dr["CourierID"];
                            courier.Name = (String)dr["Name"];
                            courier.Email = (String)dr["Email"];
                            courier.Password = (String)dr["Password"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return courier;
        }

        public Courier AddCustomer(Courier courier)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Customers(CourierID, Name, Email, Password)" +
                                               "values (@id, @name, @email, @password); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", courier.CourierID);
                    cmd.Parameters.AddWithValue("@name", courier.Name);
                    cmd.Parameters.AddWithValue("@email", courier.Email);
                    cmd.Parameters.AddWithValue("@password", courier.Password);

                    cn.Open();

                    courier.CourierID = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return courier;
        }

        public int UpdateCourier(Courier courier)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update Couriers SET Name = @name where CourierID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", courier.CourierID);
                    cmd.Parameters.AddWithValue("@name", courier.Name);

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

        public int DeleteCourier(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Couriers WHERE CourierID = @id";

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
