namespace proAgil.webApi.Model
{
    public class Evento
    {
        public int eventoId { get; set; }
        public string tema { get; set; }
        public string local { get; set; }
        public string lote { get; set; }
        public int qtdePessoas { get; set; }
        public string dataEvento { get; set; }

        public string ImageUrl{ get; set; }
    }
}