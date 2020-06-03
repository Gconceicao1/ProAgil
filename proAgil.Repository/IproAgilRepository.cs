using System.Threading.Tasks;
using proAgil.Domain;

namespace proAgil.Repository
{
    public interface IproAgilRepository
    {
        // interfaces gerais
      void Add<T>(T entity) where T: class;
      void Update<T>(T entity) where T: class;
      void Delete<T>(T entity) where T: class;

         Task<bool> SaveChangesAsync();

         // listagem de eventos
         Task<Evento[]> getAllEventoAsyncBytema( string tema, bool includePalestrante);
         Task<Evento[]> getAllEventoAsync(bool includePalestrante);
         Task<Evento> getAllEventoAsyncByid( int EventoId, bool includePalestrante);
        // Palestrantes
         Task<Palestrante> getAllPalestranteAsync(int PalestranteId, bool includeEventos);
        Task<Palestrante[]> getAllPalestranteAsyncBynome(string nome, bool includeEventos);
       
    }
}