using System.Linq;
using System.Threading.Tasks;
using CursoAngular.Domain;
using CursoAngular.Persistence.Contexto;
using CursoAngular.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace CursoAngular.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly CursoAngularContext _contex;
        public PalestrantePersist(CursoAngularContext contex)
        {
            _contex = contex;
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query=_contex.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos){

                query = query.Include(p => p.PalestrantesEventos)
                             .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query=_contex.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos){

                query = query.Include(p => p.PalestrantesEventos)
                             .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query=_contex.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos){

                query = query.Include(p => p.PalestrantesEventos)
                             .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

    }
}