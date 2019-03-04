using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;
using WebApi.Repositorios;

namespace WebApi.Services
{
    public class FuncionarioService
    {
        private FuncionarioRepositorio repositorio = new FuncionarioRepositorio();

        public List<Funcionario> GetByDepartamentoId(int departamentoId)
        {
            return repositorio.GetByDepartamentoId(departamentoId);
        }

        public List<Funcionario> Get()
        {
            return repositorio.Get();
        }

        public void Create(Funcionario funcionario)
        {
            repositorio.Create(funcionario);
        }
    }
}