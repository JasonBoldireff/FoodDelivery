using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UsersManager
    {
        public UsersDB UserDB { get; }

        public UsersManager(IConfiguration configuration)
        {
            UserDB = new UsersDB(configuration);
        }

        public List<User> GetUser()
        {
            return UserDB.GetUsers();
        }

        public User GetUser(int id)
        {
            return UserDB.GetUser(id);
        }

        public User AddUser(User user)
        {
            return UserDB.AddUser(user);
        }

        public int UpdateUser(User user)
        {
            return UserDB.UpdateUser(user);
        }

        public int DeleteUser(int id)
        {
            return UserDB.DeleteUser(id);
        }
    }
}
