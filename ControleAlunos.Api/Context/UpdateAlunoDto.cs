using System.ComponentModel.DataAnnotations;

namespace ControleAlunos.Api.Context
{
    public class UpdateAlunoDto
    {
        [Required(ErrorMessage = "O nome do aluno é obrigatório")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O endereço do aluno é obrigatório")]
        public string? Endereco { get; set; }
        [Required(ErrorMessage = "O nome do pai ou da mãe do aluno é obrigatório")]
        public string? NomePaiOuMae { get; set; }
        [Required(ErrorMessage = "A idade do aluno é obrigatório")]
        public int? Idade { get; set; }
        [Required(ErrorMessage = "O ID da turma é obrigatório")]
        public int? TurmaId { get; set; }

    }
}
