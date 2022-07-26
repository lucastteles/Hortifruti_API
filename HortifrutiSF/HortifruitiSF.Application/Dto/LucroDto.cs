using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Dto
{
    public class LucroDto
    {
        public string NomeProduto { get; set; }
        public int QuantidadeVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal Lucro { get; set; }
        public DateTime Data { get; set; }
        public Guid ProdutoId { get; set; }
    }
}
