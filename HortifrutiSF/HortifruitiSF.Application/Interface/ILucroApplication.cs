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
        Task<LucroDto> ObterTodaVendaPorProduto(Guid idProduto, DateTime? data);
    }
}
