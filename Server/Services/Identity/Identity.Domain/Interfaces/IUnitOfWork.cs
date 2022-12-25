namespace Identity.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveDbAsync();
    }
}
