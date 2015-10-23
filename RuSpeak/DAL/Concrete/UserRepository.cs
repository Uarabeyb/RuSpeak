using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RuSpeak.DAL.Abstract;
using RuSpeak.Models;
using RuSpeak.Models.Auth;

namespace RuSpeak.DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        //private readonly MyContext _context = new MyContext();

        public IEnumerable<User> Users
        {
            get
            {
                using (var context = new MyContext())
                {
                    return context.Users.ToList();
                }
            }
        }

        public void SaveUser(User user)
        {
            using (var context = new MyContext())
            {
                if (user.UserId == 0)
                {
                    user.RegisterDate = DateTime.Now;
                    context.Users.Add(user);
                }
                else
                {
                    context.Users.Attach(user);
                    context.Entry(user).State = EntityState.Modified;
                }
                context.SaveChanges(); 
            }
        }

        public void DeleteUser(int id)
        {
            
            using (var context = new MyContext())
            {
                var user = context.Users.FirstOrDefault(t => t.UserId == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                } 
            }
        }

        public User Login(string email, string password)
        {
            using (var context = new MyContext())
            {
                return context.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password); 
            }
        }

        public User GetUser(string email)
        {
            using (var context = new MyContext())
            {
                return context.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0); 
            }
        }

        public User GetUser(int id)
        {
            using (var context = new MyContext())
            {
                return context.Users.SingleOrDefault(p => p.UserId == id); 
            }
        }
    }
}