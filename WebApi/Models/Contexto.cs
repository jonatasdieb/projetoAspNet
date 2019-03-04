namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Custo> Custos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
