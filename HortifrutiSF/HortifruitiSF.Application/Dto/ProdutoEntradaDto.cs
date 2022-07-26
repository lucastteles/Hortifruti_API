using HortifrutiSF.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Dto
{
    public class ProdutoEntradaDto
    {
        public Guid IdProdutoEntrada { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public float Peso { get; set; }
        public string Fornecedor { get; set; }
        public decimal PrecoCusto { get; set; }
        public string Data { get; set; }
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
    }
}
