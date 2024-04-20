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
public class TurmaController : ControllerBase
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly AppDbContext _appDbContext;
    private IMapper _mapper;

    public TurmaController(ITurmaRepository turmaRepository, AppDbContext appDbContext, IMapper mapper)
    {
        _turmaRepository = turmaRepository;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaTurma([FromBody] CadastrarTurmaDto turmaDto)
    {
        Turma turma = _mapper.Map<Turma>(turmaDto);
        _appDbContext.Turma.Add(turma);
        _appDbContext.SaveChanges();
        return CreatedAtAction(nameof(LerTurmaPorId), new { id = turma }, turma);
    }

    [HttpGet]
    public IEnumerable<ReadTurmaDto> LerTurma()
    {

        return _mapper.Map<List<ReadTurmaDto>>(_appDbContext.Turma.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult LerTurmaPorId(int id)
    {
        var turma = _appDbContext.Turma.FirstOrDefault(turma => turma.Id == id);
        if (turma == null) return NotFound();
        var turmaDto = _mapper.Map<ReadTurmaDto>(turma);
        return Ok(turmaDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarTurma(int id, [FromBody]
    UpdateTurmaDto turmaDto)
    {
        var turma = _appDbContext.Turma.FirstOrDefault(
            turma => turma.Id == id);
        if (turma == null) return NotFound();
        _mapper.Map(turmaDto, turma);
        _appDbContext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarTurmaParcial(int id, JsonPatchDocument<UpdateTurmaDto> patch)
    {
        var turma = _appDbContext.Turma.FirstOrDefault(
            turma => turma.Id == id);
        if (turma == null) return NotFound();
        var turmaParaAtualizar = _mapper.Map<UpdateTurmaDto>(turma);
        patch.ApplyTo(turmaParaAtualizar, ModelState);
        if (!TryValidateModel(turmaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(turmaParaAtualizar, turma);
        _appDbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarTurma(int id)
    {
        var turma = _appDbContext.Turma.FirstOrDefault(
            turma => turma.Id == id);
        if (turma == null) return NotFound();
        _appDbContext.Remove(turma);
        _appDbContext.SaveChanges();
        return NoContent();
    }
}
