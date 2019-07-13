using System.Linq;

namespace TestNinja.FundamentalsInterfaces
{
    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }
}