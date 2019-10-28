using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICouriersManager
    {
        ICouriersDB CourierDB { get; }

        List<Courier> GetCouriers();

        Courier GetCourier(int id);

        Courier AddCustomer(Courier courier);

        int UpdateCourier(Courier courier);

        int DeleteCourier(int id);
    }
}
