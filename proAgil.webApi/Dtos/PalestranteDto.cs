using System.Collections.Generic;

namespace proAgil.webApi.Dtos
{
    public class PalestranteDto
    {
           public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imageUrl { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

    public List<RedeSocialDto> RedesSociais { get; set; }
      public List<EventoDto>  Eventos { get; set; }
    }
}