using ControleAlunos.Models.DTOs;

namespace ControleAlunos.Web.Services
{
    public interface ITurmaService
    {
        Task<IEnumerable<TurmaDto>> GetTurmas();
        Task CadastrarTurma(string nomeDaTurma, string professor, string turno);
    }
}
