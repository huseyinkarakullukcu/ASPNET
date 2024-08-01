using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T> //type
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    }
}