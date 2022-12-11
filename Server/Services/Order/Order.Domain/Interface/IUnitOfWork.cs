namespace Order.Domain.Interface
{
    public interface IUnitOfWork 
    {
        Task<bool> SaveDbAsync();
    }
}
