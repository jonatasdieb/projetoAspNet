using WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Repositorios
{

    public  class DepartamentoRepositorio
    {
        private Contexto db;

        public void Create(Departamento departamento)
        {

            using (db = new Contexto())
            {
                db.Departamentos.Add(departamento);
                db.SaveChanges();
            }
        }

        public List<Departamento> Get()
        {
            using (db = new Contexto())
            {
             return   db.Departamentos.ToList();                
            }
        }
    }
}
