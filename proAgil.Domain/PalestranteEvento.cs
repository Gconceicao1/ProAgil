namespace proAgil.Domain
{
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }
        public Palestrante palestrante { get; set; }
        
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}