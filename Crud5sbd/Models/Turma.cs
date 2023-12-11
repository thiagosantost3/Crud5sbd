namespace Crud5sbd.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string? Turno { get; set; }

        public Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }

        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }

        public List<AlunoTurma> AlunoTurma { get; set; }
        
    }
}
