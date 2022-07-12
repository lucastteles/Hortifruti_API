using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.ViewModel
{
    public class EstoqueViewModel
    {
        public int QuantidadeEstoque { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid Id { get; set; }
    }
}
