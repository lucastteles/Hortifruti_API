using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Dto
{
    public class ProdutoDto
    {
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal PrecoVenda { get; set; }
        public DateTime Data { get; set; }
    }
}
