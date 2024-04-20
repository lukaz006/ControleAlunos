using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ControleAlunos.Api.Context
{
    public class ReadAlunoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? NomePaiOuMae { get; set; }
        public int? Idade { get; set; }
        [JsonIgnore]
        public int? TurmaId { get; set; }
        public string? Turma { get; set; }        
    }
}
