using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Dto
{
    public class LucroDto
    {
        public string NomeProduto { get; set; }
        public int QuantidadeVenda { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal PrecoCusto { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Lucro { get; set; }

        public DateTime Data { get; set; }
        public Guid ProdutoId { get; set; }
    }
}
