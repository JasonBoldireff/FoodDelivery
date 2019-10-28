using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CouriersManager
    {
        public CouriersDB CourierDB { get; }

        public CouriersManager(IConfiguration configuration)
        {
            CourierDB = new CouriersDB(configuration);
        }

        public List<Courier> GetCouriers()
        {
            return CourierDB.GetCouriers();
        }

        public Courier GetCourier(int id)
        {
            return CourierDB.GetCourier(id);
        }

        public Courier AddCustomer(Courier courier)
        {
            return CourierDB.AddCustomer(courier);
        }

        public int UpdateCourier(Courier courier)
        {
            return CourierDB.UpdateCourier(courier);
        }

        public int DeleteCourier(int id)
        {
            return CourierDB.DeleteCourier(id);
        }
    }
}

