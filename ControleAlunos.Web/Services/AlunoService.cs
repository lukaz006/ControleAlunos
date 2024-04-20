using ControleAlunos.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace ControleAlunos.Web.Services
{
    public class AlunoService : IAlunoService
    {
        public HttpClient _httpClient;
        public ILogger<AlunoService> _logger;

        public AlunoService(HttpClient httpClient, ILogger<AlunoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<AlunosDto>> GetAlunos()
        {
            try
            {
                var alunosDtos = await _httpClient.GetFromJsonAsync<IEnumerable<AlunosDto>>("api/alunos");
                return alunosDtos;
            }

            catch (Exception) 
            {
                _logger.LogError("Erro ao acessar alunos: api/alunos");
                throw;
            }
        }
        public async Task<AlunosDto> GetAluno(int id)
        {
            try
            {
                var alunosDtos = await _httpClient.GetFromJsonAsync<AlunosDto>($"api/alunos/{id}");
                return alunosDtos;
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao acessar alunos: api/alunos");
                throw;
            }
        }
        public async Task RegistrarPresenca(int alunoId, bool presenca)
        {
            try
            {
                var registroDto = new RegistroDto
                {
                    AlunoId = alunoId,
                    Presenca = presenca
                };

                await _httpClient.PostAsJsonAsync("api/registro", registroDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao registrar presença/falta para o aluno com ID {alunoId}: {ex.Message}");
                throw;
            }
        }        
        public async Task CadastrarAluno(string nome, string endereco, string nomeDosPais, int idade, int turmaId)
        {
            try
            {
                var cadastrarAlunoDto = new AlunosDto
                {
                    Nome = nome,
                    Endereco = endereco,
                    NomePaiOuMae = nomeDosPais,
                    Idade = idade,
                    TurmaId = turmaId
                };

                await _httpClient.PostAsJsonAsync("api/alunos", cadastrarAlunoDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao registrar aluno: {ex.Message}");
                throw;
            }
        }
        public async Task DeletarAluno(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"api/alunos/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar aluno: {ex.Message}");
                throw;
            }
        }
        public async Task AtualizarAluno(int id, AlunosDto alunoAtualizado)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/alunos/{id}", alunoAtualizado);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar aluno: {ex.Message}");
                throw;
            }
        }
    }
}
