using System.Threading.Tasks;
using CursoAngular.Domain;

namespace CursoAngular.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
         //PALESTRANTES
         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
         Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}