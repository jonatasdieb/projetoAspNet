using WebApi.Repositorios;
using WebApi.Models;
using WebApi.Helpers;
using WebApi.ViewModels;
using System;

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

        public void Create(UserViewModel user)
        {
            var exists = getByUsername(user.Username);

            if (exists == null)
            {
                User usuario = new User();
                usuario.Username = user.Username;
                usuario.Password = Encrypt.MD5Hash(user.Password);
                repositorio.Create(usuario);
            } 
            else
            {
                throw new Exception("Nome de usuário já existe.");
            }

            
            
        }

        public User getByUsername(string username)
        {
           return repositorio.getByUsername(username);
        }
    }
}