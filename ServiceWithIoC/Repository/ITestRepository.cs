using System.Collections;
using System.Linq;

namespace ServiceWithIoC.Repository
{
    public interface ITestRepository : IQueryable, IEnumerable
    {
        IQueryable Get();
    }
}