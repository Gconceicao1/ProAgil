using System.Collections.Generic;

namespace proAgil.Domain
{
    public class Palestrante
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imageUrl { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

    public List<RedeSocial> RedesSociais { get; set; }
      public List<PalestranteEvento>  PalestrantesEventos { get; set; }
    }
}