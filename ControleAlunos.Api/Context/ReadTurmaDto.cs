using ControleAlunos.Api.Entities;
using System.Text.Json.Serialization;

namespace ControleAlunos.Api.Context
{
    public class ReadTurmaDto
    {
        public int Id { get; set; }
        public string? NomeDaTurma { get; set; }
        public string? Professor { get; set; }
        public string? Turno { get; set; }
        public IEnumerable<string>? Alunos { get; set; }        
    }
}
