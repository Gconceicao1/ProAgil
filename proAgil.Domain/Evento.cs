using System;
using System.Collections.Generic;

namespace proAgil.Domain
{
    public class Evento
    {
        public int id { get; set; }
        public string tema { get; set; }
        public string local { get; set; }
        public int qtdePessoas { get; set; }
        public DateTime dataEvento { get; set; }

        public string imageUrl{ get; set; }

        public string telefone { get; set; }

        public string email { get; set; }
        public string lote { get; set; }
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<PalestranteEvento>  PalestrantesEventos { get; set; }

    }
}