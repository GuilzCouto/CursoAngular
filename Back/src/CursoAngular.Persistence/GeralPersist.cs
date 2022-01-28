using System.Threading.Tasks;
using CursoAngular.Persistence.Contexto;
using CursoAngular.Persistence.Contratos;

namespace CursoAngular.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly CursoAngularContext _contex;
        public GeralPersist(CursoAngularContext contex)
        {
            _contex = contex;
        }
        public void Add<T>(T entity) where T : class
        {
            _contex.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _contex.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _contex.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _contex.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _contex.SaveChangesAsync()) > 0;
        }
    }
}