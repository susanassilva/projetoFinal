using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Models; 

namespace SistemaEscolar.Context 
{
    public class SistemaEscolarContext : DbContext
    {
        public SistemaEscolarContext(DbContextOptions<SistemaEscolarContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>().ToTable("turma");
            modelBuilder.Entity<Aluno>().ToTable("aluno");

        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Turma> Turma { get; set; }

        

    }
}
