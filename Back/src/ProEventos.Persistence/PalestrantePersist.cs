using System.Linq;
using System.Threading.Tasks;
using Back.src.ProEventos.Domain;
using Back.src.ProEventos.Persistence.Contexto;
using Back.src.ProEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Back.src.ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }             
       
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrante.Include(p => p.RedeSociais);
            if (includeEventos)
            {
                query = query.Include(p => p.PalestranteEventos).ThenInclude(e => e.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrante.Include(p => p.RedeSociais);
            if (includeEventos)
            {
                query = query.Include(p => p.PalestranteEventos).ThenInclude(e => e.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == palestranteId);
            return await query.FirstOrDefaultAsync();
        }


        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrante.Include(pe => pe.RedeSociais);
            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos).ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(pe => pe.Id);
            return await query.ToArrayAsync();
        }

    }

}