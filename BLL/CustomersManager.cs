using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class CustomersManager
    {
        public CustomersDB CustomerDB{ get; }

        public CustomersManager(IConfiguration configuration)
        {
            CustomerDB = new CustomersDB(configuration);
        }

        public List<Customer> GetCustomers()
        {
            return CustomerDB.GetCustomers();
        }

        public Customer GetCustomer(int id)
        {
            return CustomerDB.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomerDB.AddCustomer(customer);
        }

        public int UpdateCustomer(Customer customer)
        {
            return CustomerDB.UpdateCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return CustomerDB.DeleteCustomer(id);
        }
    }
}
