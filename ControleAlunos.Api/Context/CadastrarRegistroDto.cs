using ControleAlunos.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace ControleAlunos.Api.Context
{
    public class CadastrarRegistroDto
    {        
        [Required(ErrorMessage = "O ID do aluno é obrigatório")]
        public int? AlunoId { get; set; }
        [Required(ErrorMessage = "O controle de presença é obrigatório")]      
        public bool? Presenca { get; set; }
    }
}
