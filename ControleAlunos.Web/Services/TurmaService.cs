using ControleAlunos.Models.DTOs;
using System.Net.Http.Json;

namespace ControleAlunos.Web.Services
{
    public class TurmaService : ITurmaService
    {
        public HttpClient _httpClient;
        public ILogger<TurmaService> _logger;

        public TurmaService(HttpClient httpClient, ILogger<TurmaService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<TurmaDto>> GetTurmas()
        {
            try
            {
                var turmasDtos = await _httpClient.GetFromJsonAsync<IEnumerable<TurmaDto>>("api/turma");
                return turmasDtos;
            }

            catch (Exception) 
            {
                _logger.LogError("Erro ao acessar alunos: api/turma");
                throw;
            }
        }
        public async Task CadastrarTurma(string nomeDaTurma, string professor, string turno)
        {
            try
            {
                var cadastrarTurmaDto = new TurmaDto
                {
                    NomeDaTurma = nomeDaTurma,
                    Professor = professor,
                    Turno = turno
                };

                await _httpClient.PostAsJsonAsync("api/turma", cadastrarTurmaDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao registrar turma: {ex.Message}");
                throw;
            }
        }
    }
}
