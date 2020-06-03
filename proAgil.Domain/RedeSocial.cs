namespace proAgil.Domain
{
    public class RedeSocial
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string url { get; set; }

        public int ? EventoId { get; set; }
        public Evento Evento { get; }
        public int ? PalestranteId { get; set; }
        public Palestrante Palestrante { get; }
    }
}