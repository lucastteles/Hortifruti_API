using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Dto
{
    public class EstoqueDto
    {
        public Guid EstoqueId { get; set; }
        public int QuantidadeEstoque { get; set; }
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
    }
}
