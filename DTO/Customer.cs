using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Customer : User
    {
        //Creat Default Constructor
        public Customer() { }
        //Save Address of User and give other information to upper Class when creating an object
        public Customer(String Address, int CityCode, String Name, String Email, String Password) : base(CityCode, Name, Email, Password)
        {
            this.Address = Address;
        }
        public int CustomerID { get; set; }
        public String Address { get; set; }
        public override string ToString()
        {
            return $"{Name}|{CityCode}|{Address}|{Email}|{Password}";
        }
    }
}
