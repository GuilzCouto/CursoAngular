using System.Threading.Tasks;
using CursoAngular.Domain;

namespace CursoAngular.Persistence.Contratos
{
    public interface IEventoPersist
    {
         //EVENTOS

         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
         Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
        
    }
}