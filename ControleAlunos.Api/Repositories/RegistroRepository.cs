using ControleAlunos.Api.Context;
using ControleAlunos.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleAlunos.Api.Repositories;

public class RegistroRepository : IRegistroRepository
{
    private readonly AppDbContext _context;

    public RegistroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Registro> GetRegistro(int id)
    {
        var registro = await _context.Registro.Include(a => a.Id).SingleOrDefaultAsync(a => a.Id == id);
        return registro;
    }

    public async Task<IEnumerable<Registro>> GetRegistros()
    {
        var registros = await _context.Registro.Include(p => p.Id).ToListAsync();
        return registros;
    }
}
