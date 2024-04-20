using ControleAlunos.Api.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ControleAlunos.Api.Context
{
    public class ReadRegistroDto
    {
        public int? Id { get; set; }
        public string? Data { get; set; } = DateTime.Now.ToString("G");
        public int? AlunoId { get; set; }
        public string? AlunoNome { get; set; }
        public string? AlunoTurma { get; set; }
        public bool? Presenca { get; set; }

    }
}
