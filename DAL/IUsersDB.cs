using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IUsersDB
    {
        IConfiguration Configuration { get; }

        List<User> GetUsers();

        User GetUser(int id);

        User AddUser(User user);

        int UpdateUser(User user);

        int DeleteUser(int id);
    }
}
