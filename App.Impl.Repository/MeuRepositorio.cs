using App.Domain.Contracts.Repository;
using App.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Impl.Repository
{
    public class MeuRepositorio : IMeuRepository
    {
        public IList<RetornoDto> ConsultarRetorno(int? i = null)
        {
            var retorno = new List<RetornoDto>
            {
                new RetornoDto { Prop1 = "String1", Prop2 = 1, Prop3 = DateTime.Now},
                new RetornoDto { Prop1 = "String2", Prop2 = 2, Prop3 = DateTime.Now},
                new RetornoDto { Prop1 = "String3", Prop2 = 3, Prop3 = DateTime.Now}
            };

            return i == null
                ? retorno
                : retorno.Where(r => r.Prop2 == i).ToList();
        }
    }
}
