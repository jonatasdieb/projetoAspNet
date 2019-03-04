using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;
using WebApi.Repositorios;

namespace WebApi.Services
{
    public class DepartamentoService
    {
        private DepartamentoRepositorio repositorio = new DepartamentoRepositorio();

        public List<Departamento> Get()
        {
            return repositorio.Get();
        }

        public void Create(Departamento departamento)
        {
            repositorio.Create(departamento);
        }
    }
}