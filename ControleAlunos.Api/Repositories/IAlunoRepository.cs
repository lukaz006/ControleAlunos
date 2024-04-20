using ControleAlunos.Api.Entities;

namespace ControleAlunos.Api.Repositories;

public interface IAlunoRepository
{
    Task<IEnumerable<Alunos>> GetAlunos();
    Task<Alunos> GetAluno(int id);


}
