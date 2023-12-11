namespace Crud5sbd.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public string? Sigla { get; set; }

        public string? Periodo { get; set; }

        public string? Credito { get; set; }

        public List<Turma> Turmas { get; set;}
        public List<Professor> Professors { get; set; }

    }
}
