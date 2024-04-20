using ControleAlunos.Api.Entities;

namespace ControleAlunos.Api.Repositories;

public interface ITurmaRepository
{
    Task<IEnumerable<Turma>> GetTurmas();
    Task<Turma> GetTurma(int id);
    /**Task<IEnumerable<Alunos>> GetTurmaAlunos(int id);**/
}
