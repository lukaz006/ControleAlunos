using ControleAlunos.Api.Context;
using System.ComponentModel.DataAnnotations;

namespace ControleAlunos.Api.Entities
{
    public class Registro
    {
        [Key]
        [Required]
        [MaxLength(100)]
        public int Id { get; set; }

        [Required]
        public int? AlunoId { get; set; }
        public virtual string AlunoNome { get; set; }
        public virtual string AlunoTurma { get; set; }

        [Required]
        public bool? Presenca { get; set; }
        public virtual ICollection<Alunos>? Alunos { get; set; }
        public virtual ICollection<Turma>? Turmas { get; set; }       

    }
}
