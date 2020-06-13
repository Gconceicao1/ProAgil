using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proAgil.webApi.Dtos
{
    public class EventoDto
    {
        public int id { get; set; }

        [Required (ErrorMessage= "o campo {0} é obrigatório")]
        [StringLength(100)]
        [MinLength(4,  ErrorMessage="o campo {0} deve ter no minimo 4 caracteres") ]
        [MaxLength(100,  ErrorMessage="o campo {0} deve ter no maximo 100 caracteres") ]
        public string tema { get; set; }
        public string local { get; set; }
        
        [Required (ErrorMessage= "o campo {0} é obrigatório")]
        
        [Range(2 , 120000 ,  ErrorMessage="o campo {0} deve ter entre 2 a 120000 ") ]

        public int qtdePessoas { get; set; }

        [Required (ErrorMessage= "o campo {0} é obrigatório")]
        public DateTime dataEvento { get; set; }

        public string imageUrl{ get; set; }

        [Phone]
        public string telefone { get; set; }

        [Required (ErrorMessage= "o campo {0} é obrigatório")]
        [EmailAddress (ErrorMessage="o campo deve ser um {0} valido") ]
        public string email { get; set; }
        public string lote { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto>  Palestrante { get; set; }

    }
}