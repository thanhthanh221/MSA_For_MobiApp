namespace Order.Domain.Interface
{
    public interface IUnitOfWork 
    {
        Task<int> SaveChangesAsync();
    }
}
