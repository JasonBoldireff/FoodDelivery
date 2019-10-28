using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class User
    {
        //Default Constructor
        public User()
        {

        }
        //Constructor
        public User(int CityCode, String Name, String Email, String Password)
        {
            this.CityCode = CityCode;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
        }

        public int UserID { get; set; }
        public int CityCode { get; set; }
        public String Name { get; set; }
        public String Email{ get; set; }
        public String Password { get; set; }


        public override string ToString()
        {
            return $"{UserID}|{CityCode}|{Name}|{Email}|{Password}";
        }
    }
}
