using System.Collections.Generic;
using Skeleton.Domain.Repositories;
using Skeleton.Domain.Services;

namespace Skeleton.Impl.Services
{
    public class ValuesServices : IValuesService
    {
        private readonly IValuesRepository _valuesRepository;

        public ValuesServices(IValuesRepository valuesRepository)
        {
            _valuesRepository = valuesRepository;
        }

        public IEnumerable<string> GetValues() => _valuesRepository.SearchValues();
    }
}
