using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Dto
{
    public class VendaDto
    {
        public Guid VendaId { get; set; }
        public int QuantidadeVenda { get; set; }
        public string Data { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorTotal { get; set; }
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
    }
}
