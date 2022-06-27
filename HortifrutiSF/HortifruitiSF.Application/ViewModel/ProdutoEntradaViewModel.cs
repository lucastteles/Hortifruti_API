using HortifrutiSF.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.ViewModel
{
    public class ProdutoEntradaViewModel
    {
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public float Peso { get; set; }
        public string Fornecedor { get; set; }
        public Guid ProdutoId { get; set; }
       
    }
}
