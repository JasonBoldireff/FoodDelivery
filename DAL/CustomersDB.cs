using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class CustomersDB : ICustomersDB
    {
        public IConfiguration Configuration { get; }
        public CustomersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Customer> GetCustomers() //if we know the query returns multiple results use while loop
        {
            List<Customer> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Customers";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customer>();

                            Customer customer = new Customer();

                            customer.CityCode = (int)dr["CityCode"];
                            customer.CustomerID = (int)dr["CustomerID"];
                            customer.Name = (String)dr["Name"];
                            customer.Email = (String)dr["Email"];
                            customer.Password = (String)dr["Password"];
                            customer.Address = (String)dr["Address"];
                        
                            results.Add(customer);
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

        public Customer GetCustomer(int id) //when we know the return is only one result we use an IF-loop as decision maker
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Customers where CustomerID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customer = new Customer();

                            customer.CustomerID = (int)dr["CustomerID"];
                            customer.Name = (String)dr["Name"];
                            customer.Email = (String)dr["Email"];
                            customer.Password = (String)dr["Password"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return customer;
        }

        public Customer AddCustomer(Customer customer)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Customers(CustomerID, Name, Email, Password)" +
                                               "values (@id, @name, @email, @password); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                    cmd.Parameters.AddWithValue("@name", customer.Name);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@password", customer.Password);

                    cn.Open();

                    customer.CustomerID = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        public int UpdateCustomer(Customer customer)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update Customers SET Name = @name where CustomerID = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                    cmd.Parameters.AddWithValue("@name", customer.Name);

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

        public int DeleteCustomer(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Customers WHERE CustomerID = @id";

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
