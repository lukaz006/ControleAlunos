using ControleAlunos.Api.Entities;

namespace ControleAlunos.Api.Repositories;

public interface IRegistroRepository
{
    Task<IEnumerable<Registro>> GetRegistros();
    Task<Registro> GetRegistro(int id);

}
