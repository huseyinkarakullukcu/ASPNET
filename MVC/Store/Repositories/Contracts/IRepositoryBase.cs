namespace Repositories.Contracts
{
    public interface IRepositoryBase<T> //type
    {
        IQueryable<T> FindAll(bool trackChanges);
    }
}