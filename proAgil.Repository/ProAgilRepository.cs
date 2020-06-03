using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proAgil.Domain;
using proAgil.Repository;

namespace proAgil.Repository
{
    public class ProAgilRepository : IproAgilRepository
    {

        private readonly proAgilContext _context;

        public ProAgilRepository(proAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // METODOS GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync())> 0;
        }


        // METODOS EVENTOS 
        public async Task<Evento[]> getAllEventoAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include (c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrante){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.palestrante);
            }
            
            query = query.AsNoTracking().OrderByDescending(c => c.dataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> getAllEventoAsyncByid(int EventoId, bool includePalestrante)
        {
              IQueryable<Evento> query = _context.Eventos
            .Include (c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrante){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.palestrante);
            }
            
            query = query.AsNoTracking().OrderByDescending(c => c.dataEvento).Where(c => c.id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public  async Task<Evento[]> getAllEventoAsyncBytema(string tema, bool includePalestrante)
        {
             IQueryable<Evento> query = _context.Eventos
            .Include (c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrante){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.palestrante);
            }
            
            query = query.OrderByDescending(c => c.dataEvento).Where(c => c.tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }


        // METODOS PALESTRANTES 
        public async Task<Palestrante> getAllPalestranteAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(c => c.RedesSociais);

            if(includeEventos){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }
            
            query = query.OrderBy(p => p.nome).Where(p => p.id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> getAllPalestranteAsyncBynome(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(c => c.RedesSociais);

            if(includeEventos){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }
            
            query = query.Where(p => p.nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }


    }
}