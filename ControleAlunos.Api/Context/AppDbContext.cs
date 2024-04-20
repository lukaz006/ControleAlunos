using ControleAlunos.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunos.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Alunos>? Alunos { get; set; }
        public DbSet<Turma>? Turma { get; set; }
        public DbSet<Registro>? Registro { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>().HasData(new Turma
            {
                Id = 1,
                NomeDaTurma = "Natação",
                Professor = "Sebastião",
                Turno = "Manhã",




            });

            modelBuilder.Entity<Alunos>().HasData(new Alunos 
            {
                Id = 1,
                Nome = "Lucas",
                Endereco = "Rua Augusto Mendes Pinto - 164",
                NomePaiOuMae = "Iraneide Rocha",
                Idade = 29,
                TurmaId = 1,
                
                
                

            });




        }
    }
}
