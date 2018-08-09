using App.Domain.Contracts.Repository;
using App.Domain.Contracts.Service;
using App.Domain.Dto;
using System.Collections.Generic;

namespace App.Impl.Service
{
    public class MeuService : IMeuService
    {
        private readonly IMeuRepository _repository;
        public MeuService(IMeuRepository repository)
        {
           _repository = repository;
        }

        public RetornoDto RetornarAlgo(int i)
        {
            var retorno = _repository.ConsultarRetorno(i);
            return retorno.Count > 0
                ? retorno[0]
                : null;
        }

        public IList<RetornoDto> RetornarTudo()
        {
            return _repository.ConsultarRetorno();
        }
    }
}
