using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ControleAlunos.Models.DTOs;

public class TurmaDto
{
    public int Id { get; set; }
    public string? NomeDaTurma { get; set; }
    public string Professor { get; set; }
    public string Turno { get; set; }

    public virtual ICollection<AlunosDto> ListaAlunos { get; set; }
}
