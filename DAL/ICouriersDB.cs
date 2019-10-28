using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ICouriersDB
    {
        IConfiguration Configuration { get; }

        List<Courier> GetCouriers();

        Courier GetCourier(int id);

        Courier AddCustomer(Courier courier);

        int UpdateCourier(Courier courier);

        int DeleteCourier(int id);
    }
}
