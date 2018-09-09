using Skeleton.Domain.Repositories;
using System.Collections.Generic;

namespace Skeleton.Impl.Repositories
{
    public class ValuesRepository : IValuesRepository
    {
        public IEnumerable<string> SearchValues()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
