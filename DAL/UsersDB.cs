using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class UsersDB : IUsersDB
    {
        public IConfiguration Configuration { get; }
        public UsersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<User> GetUsers() //if we know the query returns multiple results use while loop
        {
            List<User> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Users";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<User>();

                            User user = new User();

                            user.CityCode = (int)dr["CityCode"];
                            user.Name = (String)dr["Name"];
                            user.Email = (String)dr["Email"];
                            user.Password = (String)dr["Password"];

                        
                            results.Add(user);
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

        public User GetUser(int id) //when we know the return is only one result we use an IF-loop as decision maker
        {
            User user = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Users where UserID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            user = new User();

                            user.UserID = (int)dr["UserID"];
                            user.Name = (String)dr["Name"];
                            user.Email = (String)dr["Email"];
                            user.Password = (String)dr["Password"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }

        public User AddUser(User user)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Users(UserID, Name, Email, Password)" +
                                               "values (@id, @name, @email, @password); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", user.UserID);
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);

                    cn.Open();

                    user.UserID = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return user;
        }

        public int UpdateUser(User user)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update Users SET Name = @name where CourierID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", user.UserID);
                    cmd.Parameters.AddWithValue("@name", user.Name);

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

        public int DeleteUser(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE UserID = @id";

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
