using ControleAlunos.Api.Context;
using ControleAlunos.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ControleAlunos.Api.Entities;

public class Alunos
{
    [Key]
    [Required]
    [MaxLength(100)]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    
    public string? NomePaiOuMae { get; set; }
    public int? Idade { get; set; }
    [Required]
    public int TurmaId { get; set; }
    public virtual Turma? Turma { get; set; }
    public virtual Registro? Registro { get; set; }
}
