using Microsoft.EntityFrameworkCore;
using Crud5sbd.Models;

namespace Crud5sbd.DataBase
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados(DbContextOptions<BancoDeDados> options) : base(options)
        {

        }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Turma> Turma { get; set; } 
        public DbSet<Aluno> Aluno { get; set; } 
        public DbSet<AlunoTurma> AlunoTurma { get; set; } 
    }
}
