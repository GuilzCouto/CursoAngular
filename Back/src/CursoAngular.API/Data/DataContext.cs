using CursoAngular.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoAngular.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
    }
}