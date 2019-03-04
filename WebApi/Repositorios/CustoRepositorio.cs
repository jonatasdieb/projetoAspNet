using WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace WebApi.Repositorios
{
    public class CustoRepositorio
    {
        private Contexto db;

        public List<Custo> Get()
        {
            using (db = new Contexto())
            {
                return db.Custos
                    .Include(x => x.Departamento)
                    .Include(x => x.Funcionario).ToList();
            }
        }

        public void Create(Custo custo)
        {
            using (db = new Contexto())
            {
                db.Custos.Add(custo);
                db.SaveChanges();
            }
        }

        public List<Custo> GetByFuncionarioId(int funcionarioId)
        {
            using (db = new Contexto())
            {
                return db.Custos
                    .Include(x => x.Departamento)
                    .Include(x => x.Funcionario).Where(x => x.FuncionarioId == funcionarioId).ToList();
            }
        }

        public List<Custo> GetByDescricao(string descricao)
        {
            using (db = new Contexto())
            {
                return db.Custos
                      .Include(x => x.Departamento)
                      .Include(x => x.Funcionario).Where(x => x.Descricao.Contains(descricao)).ToList();
            }
        }

        public void ImportarExcel(List<Custo> custos)
        {
            using (db = new Contexto())
            {
                foreach(var custo in custos)
                {
                    var departamentoId = db.Funcionarios.FirstOrDefault(x => x.Id == custo.FuncionarioId).DepartamentoId;
                    custo.DepartamentoId = departamentoId;
                    db.Custos.Add(custo);                   
                }

                db.SaveChanges();
            }
        }
    }
}
