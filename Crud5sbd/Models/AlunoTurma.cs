namespace Crud5sbd.Models
{
    public class AlunoTurma
    {
        public int Id { get; set; }
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }

        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }

        public List<Aluno> Alunos { get; set; }
       
    }
}
