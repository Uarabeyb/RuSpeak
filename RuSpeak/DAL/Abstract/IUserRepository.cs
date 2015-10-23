using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuSpeak.Models.Auth;

namespace RuSpeak.DAL.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void SaveUser(User user);
        void DeleteUser(int id);
        User Login(string email, string password);
        User GetUser(string email);
        User GetUser(int id);
    }
}