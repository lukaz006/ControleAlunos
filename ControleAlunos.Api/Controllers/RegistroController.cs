using AutoMapper;
using ControleAlunos.Api.Context;
using ControleAlunos.Api.Entities;
using ControleAlunos.Api.Repositories;
using ControleAlunos.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistroController : ControllerBase
{
    private readonly IRegistroRepository _registroRepository;
    private readonly AppDbContext _appDbContext;
    private IMapper _mapper;

    public RegistroController(IRegistroRepository registroRepository, AppDbContext appDbContext, IMapper mapper)
    {
        _registroRepository = registroRepository;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult RegistrarPresenca([FromBody] CadastrarRegistroDto registroDto)
    {
        // Verifica se o aluno com o ID fornecido existe
        var aluno = _appDbContext.Alunos.FirstOrDefault(a => a.Id == registroDto.AlunoId);
        if (aluno == null)
        {
            return NotFound("Aluno não encontrado.");
        }

        // Cria um novo registro com as informações do aluno
        var novoRegistro = new Registro
        {
            AlunoId = registroDto.AlunoId,
            AlunoNome = aluno.Nome,
            AlunoTurma = aluno.Turma?.NomeDaTurma,
            Presenca = registroDto.Presenca
        };

        // Adiciona o novo registro ao contexto e salva as alterações
        _appDbContext.Registro.Add(novoRegistro);
        _appDbContext.SaveChanges();

        // Retorna o novo registro criado
        return CreatedAtAction(nameof(LerRegistroPorId), new { id = novoRegistro.Id }, novoRegistro);
    }

    [HttpGet]
    public IEnumerable<ReadRegistroDto> LerRegistros()
    {


        return _mapper.Map<List<ReadRegistroDto>>(_appDbContext.Registro.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult LerRegistroPorId(int id)
    {
        var registro = _appDbContext.Registro.FirstOrDefault(registro => registro.Id == id);
        if (registro == null) return NotFound();
        var registroDto = _mapper.Map<ReadRegistroDto>(registro);
        return Ok(registroDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarRegistro(int id, [FromBody]
    UpdateRegistroDto registroDto)
    {
        var registro = _appDbContext.Registro.FirstOrDefault(
            registro => registro.Id == id);
        if (registro == null) return NotFound();
        _mapper.Map(registroDto, registro);
        _appDbContext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarRegistroParcial(int id, JsonPatchDocument<UpdateRegistroDto> patch)
    {
        var registro = _appDbContext.Registro.FirstOrDefault(
            registro => registro.Id == id);
        if (registro == null) return NotFound();
        var registroParaAtualizar = _mapper.Map<UpdateRegistroDto>(registro);
        patch.ApplyTo(registroParaAtualizar, ModelState);
        if (!TryValidateModel(registroParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(registroParaAtualizar, registro);
        _appDbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarRegistro(int id)
    {
        var registro = _appDbContext.Registro.FirstOrDefault(
            registro => registro.Id == id);
        if (registro == null) return NotFound();
        _appDbContext.Remove(registro);
        _appDbContext.SaveChanges();
        return NoContent();
    }
}
