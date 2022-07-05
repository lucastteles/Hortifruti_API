using System;
using System.Collections.Generic;
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
        public decimal ValorTotal { get; set; }
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
    }
}
