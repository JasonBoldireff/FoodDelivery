using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class CitiesDB : ICitiesDB
    {
        public IConfiguration Configuration { get; }
        public CitiesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<City> GetCities() //if we know the query returns multiple results use while loop
        {
            List<City> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Cities";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<City>();

                            City city = new City();

                            city.CityCode = (int)dr["CityCode"];
                            city.Name = (String)dr["CityName"];
                        
                            results.Add(city);
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

        public City GetCity(int id) //when we know the return is only one result we use an IF-loop as decision maker
        {
            City city = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Cities where CityCode = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            city = new City();

                            city.CityCode = (int)dr["CityCode"];
                            city.Name = (String)dr["CityName"];
                            //restaurant.Status = (Boolean)dr["Status"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return city;
        }

        public City AddCity(City city)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Cities(CityCode, CityName)" +
                                               "values (@code, @name); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@code", city.CityCode);
                    cmd.Parameters.AddWithValue("@name", city.Name);

                    cn.Open();

                    city.CityCode = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;
        }

        public int UpdateCity(City city)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update Cities SET Name = @name where CityCode = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", city.CityCode);
                    cmd.Parameters.AddWithValue("@name", city.Name);

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

        public int DeleteCity(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Cities WHERE CityCode = @id";

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
