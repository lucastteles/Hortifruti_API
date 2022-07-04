using HortifrutiSF.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Domain.Repositories
{
    public interface IVendaRepository
    {
        Task AdicionarVenda(Venda venda);
    }
}
