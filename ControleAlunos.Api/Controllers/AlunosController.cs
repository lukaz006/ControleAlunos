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
public class AlunosController : ControllerBase
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly AppDbContext _appDbContext;
    private IMapper _mapper;

    public AlunosController(IAlunoRepository alunoRepository, AppDbContext appDbContext, IMapper mapper)
    {
        _alunoRepository = alunoRepository;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaAluno([FromBody] CadastrarAlunoDto alunoDto)
    {
        var proximoId = 1;
        while (_appDbContext.Alunos.Any(a => a.Id == proximoId))
        {
            proximoId++;
        }

        // Criar um novo aluno com o próximo ID
        Alunos novoAluno = _mapper.Map<Alunos>(alunoDto);
        novoAluno.Id = proximoId;

        // Adicionar o novo aluno ao contexto e salvar as mudanças
        _appDbContext.Alunos.Add(novoAluno);
        _appDbContext.SaveChanges();

        // Retorna uma resposta de sucesso com o novo aluno criado
        return CreatedAtAction(nameof(LerAlunoPorId), new { id = novoAluno.Id }, novoAluno);

    }

    [HttpGet]
    public  IEnumerable<ReadAlunoDto> LerAlunos()
    {

        
        return _mapper.Map<List<ReadAlunoDto>>(_appDbContext.Alunos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult LerAlunoPorId(int id)
    {
        var aluno = _appDbContext.Alunos.FirstOrDefault(aluno => aluno.Id == id);
        if (aluno == null) return NotFound();
        var alunoDto = _mapper.Map<ReadAlunoDto>(aluno);
        return Ok(alunoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarAlunos(int id, [FromBody]
    UpdateAlunoDto alunoDto)
    {
        var aluno = _appDbContext.Alunos.FirstOrDefault(
            aluno => aluno.Id == id);
        if (aluno == null) return NotFound();
        _mapper.Map(alunoDto, aluno);
        _appDbContext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarAlunosParcial(int id, JsonPatchDocument<UpdateAlunoDto> patch)
    {
        var aluno = _appDbContext.Alunos.FirstOrDefault(
            aluno => aluno.Id == id);
        if (aluno == null) return NotFound();
        var alunoParaAtualizar = _mapper.Map<UpdateAlunoDto>(aluno);
        patch.ApplyTo(alunoParaAtualizar, ModelState);
        if(!TryValidateModel(alunoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(alunoParaAtualizar, aluno);
        _appDbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarAlunos(int id)
    {
        var aluno = _appDbContext.Alunos.FirstOrDefault(
            aluno => aluno.Id == id);
        if (aluno == null) return NotFound();
        _appDbContext.Remove(aluno);
        _appDbContext.SaveChanges();
        return NoContent();
    }
}
