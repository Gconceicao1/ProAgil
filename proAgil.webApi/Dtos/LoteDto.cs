using System;

namespace proAgil.webApi.Dtos
{
    public class LoteDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public DateTime  dataInicio { get; set; }
        public DateTime  dataFim { get; set; }
        public int quantidade { get; set; }

    }
}