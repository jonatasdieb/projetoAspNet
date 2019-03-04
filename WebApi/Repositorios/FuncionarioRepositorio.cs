using WebApi.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;

namespace WebApi.Repositorios
{
    public class FuncionarioRepositorio
    {
        private Contexto db;

        public void Create(Funcionario funcionario)
        {
            using (db = new Contexto())
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
            }
        }

        public List<Funcionario> Get()
        {
            using (db = new Contexto())
            {
                return db.Funcionarios.Include(x => x.Departamento).ToList();                
            }
        }

        public List<Funcionario> GetByDepartamentoId(int departamentoId)
        {
            using (db = new Contexto())
            {
                return db.Funcionarios.Where(x => x.DepartamentoId == departamentoId).ToList();
            }
        }
    }
}
