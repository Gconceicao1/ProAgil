using Microsoft.EntityFrameworkCore;
using proAgil.webApi.Model;

namespace proAgil.webApi.Data
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext> options) : base (options) {}
        public DbSet<Evento> Eventos { get; set; }       
    }
}