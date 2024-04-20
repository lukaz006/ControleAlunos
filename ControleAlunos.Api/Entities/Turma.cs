using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
namespace ControleAlunos.Api.Entities;

public class Turma
{
    [Key]
    [Required]
    [MaxLength(100)]
    public int Id { get; set; }
    public string? NomeDaTurma { get; set; }
    public string Professor { get; set; }
    public string Turno { get; set; }
    public virtual ICollection<Alunos>? Alunos { get; set; }

    public IEnumerable<string> ObterNomesAlunos()
    {
        // Retorna uma lista apenas com os nomes dos alunos na turma
        return Alunos?.Select(aluno => aluno.Nome);
    }   
}
