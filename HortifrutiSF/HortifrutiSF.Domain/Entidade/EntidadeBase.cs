using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Domain.Entidade
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
            DataAlteracao = DateTime.Now;
            DataCadastro = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
