using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infra.Contexto
{
    public class SoftDesignContext : DbContext
    {
        public SoftDesignContext(DbContextOptions<SoftDesignContext> options) : base(options) { }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoftDesignContext).Assembly);
        }
    }
}
