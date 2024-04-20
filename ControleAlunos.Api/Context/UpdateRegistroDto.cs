using System.ComponentModel.DataAnnotations;

namespace ControleAlunos.Api.Context
{
    public class UpdateRegistroDto
    {
        [Required(ErrorMessage = "O ID do aluno é obrigatório")]
        public string? AlunoId { get; set; }
        [Required(ErrorMessage = "O controle de presença é obrigatório")]
        public int? Presenca { get; set; }
    }
}
