using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
  public interface IUsersManager
    {
        IUsersDB UserDB{ get; }
        List<User> GetUsers();

        User GetUser(int id);

        User AddUser(User user);

        int UpdateUser(User user);

        int DeleteUser(int id);
    }
}
