using Company.Infra.Repository;
using System.Collections.Generic;

namespace Skeleton.Domain.Repositories
{
    public interface IValuesRepository : IRepository
    {
        IEnumerable<string> SearchValues();
    }
}
