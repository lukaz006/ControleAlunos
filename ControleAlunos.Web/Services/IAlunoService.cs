using ControleAlunos.Models.DTOs;

namespace ControleAlunos.Web.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunosDto>> GetAlunos();
        Task<AlunosDto> GetAluno(int id);
        Task RegistrarPresenca(int alunoId, bool presenca);
        Task CadastrarAluno(string nome, string endereco, string nomeDosPais, int idade, int turmaId);
        Task DeletarAluno(int id);
        Task AtualizarAluno(int id, AlunosDto alunoAtualizado);
    }
}
