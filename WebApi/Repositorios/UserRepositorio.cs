using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Repositorios
{
    public class UserRepositorio
    {
        public bool Login(string username, string password)
        {
            using (Contexto db = new Contexto())
            {
                return db.Users.Any(user =>
                user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
            }
        }

        public void Create(User user)
        {
            using (Contexto db = new Contexto())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public User getByUsername(string username)
        {
            using(Contexto db = new Contexto())
            {
               return db.Users.Where(x => x.Username == username).FirstOrDefault();                
            }
        }
    }
}
