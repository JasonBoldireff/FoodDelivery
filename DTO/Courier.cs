using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Courier : User
    {
        public Courier() { }
        //empty Construcor, give information to upper Class when creating an object
        public Courier(int CityCode, String Name, String Email, String Password) : base(CityCode, Name, Email, Password )
        {

        }
        public int CourierID { get; set; }

        public int Amount { get; set; }
       // public Boolean Status { get; set; }


        public override string ToString()
        {
            return $"{Amount}";
        }
    }
}
