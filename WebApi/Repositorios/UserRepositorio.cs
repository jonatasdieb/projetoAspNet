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
    }
}
