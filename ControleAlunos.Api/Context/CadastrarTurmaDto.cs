using ControleAlunos.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace ControleAlunos.Api.Context
{
    public class CadastrarTurmaDto
    {
        [Required(ErrorMessage = "O nome do aluno é obrigatório")]
        public string? NomeDaTurma { get; set; }
        [Required(ErrorMessage = "O nome do professor é obrigatório")]
        public string? Professor { get; set; }
        [Required(ErrorMessage = "O turno é obrigatório")]
        public string? Turno { get; set; }
    }
}
