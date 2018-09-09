using Company.Infra.Service;
using System.Collections.Generic;

namespace Skeleton.Domain.Services
{
    public interface IValuesService : IService
    {
        IEnumerable<string> GetValues();
    }
}
