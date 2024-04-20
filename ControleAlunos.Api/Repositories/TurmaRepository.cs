using ControleAlunos.Api.Context;
using ControleAlunos.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunos.Api.Repositories;

public class TurmaRepository : ITurmaRepository
{
    private readonly AppDbContext _context;

    public TurmaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Turma> GetTurma(int id)
    {
        var turma = await _context.Turma.Include(a => a.Id).SingleOrDefaultAsync(a => a.Id == id);
        return turma;
    }

    public async Task<IEnumerable<Turma>> GetTurmas()
    {
        var turmas = await _context.Turma.Include(p => p.NomeDaTurma).ToListAsync();
        return turmas;
    }

    /**public async Task<IEnumerable<Alunos>> GetTurmaAlunos(int id)
    {
        var turma = await _context.Alunos.Include(t => t.TurmaId).Where(t => t.TurmaId ==id).ToListAsync();
        return turma;
    }**/
}
