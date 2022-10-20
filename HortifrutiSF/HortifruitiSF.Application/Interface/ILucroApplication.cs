using HortifruitiSF.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Interface
{
    public interface ILucroApplication
    {
        Task<LucroDto> ObterTodaVendaPorProduto(Guid idProduto, DateTime? data);///forma q estaava
       // Task<List<LucroDto>> ObterTodaVendaPorData(Guid idProduto, DateTime? data, DateTime? dataInicial, DateTime? dataFinal);

        //Task<List<LucroDto>> ObterTodaVendaPorData(DateTime? dataInicial, DateTime? dataFinal);
    }
}
