using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public interface ICustomersManager
    {
        ICustomersDB CustomerDB { get; }
        List<Customer> GetCustomers();

        Customer GetCustomer(int id);

        Customer AddCustomer(Customer customer);

        int UpdateCustomer(Customer customer);

        int DeleteCustomer(int id);
    }
}
