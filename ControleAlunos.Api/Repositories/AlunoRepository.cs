using ControleAlunos.Api.Context;
using ControleAlunos.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunos.Api.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly AppDbContext _context;

    public AlunoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Alunos> GetAluno(int id)
    {
        var aluno = await _context.Alunos.Include(a => a.Id).SingleOrDefaultAsync(a => a.Id == id);
        return aluno;
    }

    public async Task<IEnumerable<Alunos>> GetAlunos()
    {
        var alunos = await _context.Alunos.Include(p => p.Nome).ToListAsync();
        return alunos;
    }    

}
