using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAlunos.Models.DTOs;

public class AlunosDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; }

    public string? NomePaiOuMae { get; set; }
    public int Idade { get; set; }
    public int TurmaId { get; set; }
    
    public string Turma { get; set; }
    public bool Registro { get; set; }
    

}
