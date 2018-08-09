using App.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Contracts.Repository
{
    public interface IMeuRepository : IRepository
    {
        IList<RetornoDto> ConsultarRetorno(int? i = null);
    }
}
