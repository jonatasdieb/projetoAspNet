using WebApi.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;
using WebApi.Helpers;

namespace WebApi.Services
{
    public class UserService
    {
        public static UserRepositorio repositorio = new UserRepositorio();
        public static bool Login(string login, string senha)
        {                        
                var password = Encrypt.MD5Hash(senha);
                return repositorio.Login(login, password);
        }        
    }
}