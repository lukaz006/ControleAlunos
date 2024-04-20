using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAlunos.Models.DTOs;

public class RegistroDto
{
    public int? AlunoId { get; set; }
    public virtual string AlunoNome { get; set; }
    public virtual string AlunoTurma { get; set; }
    public bool? Presenca { get; set; }
    public virtual ICollection<AlunosDto>? Alunos { get; set; }
    public virtual ICollection<TurmaDto>? Turmas { get; set; }


}
