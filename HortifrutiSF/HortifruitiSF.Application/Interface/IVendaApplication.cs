using HortifruitiSF.Application.Dto;
using HortifruitiSF.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Interface
{
    public interface IVendaApplication
    {
        Task AdicionarVenda(VendaViewModel vendaVM);
        Task <List<VendaDto>> ObterVendaPorData(DateTime? dataInicial, DateTime? dataFinal);
        Task DeletarVenda(Guid idVenda);
    }
}
