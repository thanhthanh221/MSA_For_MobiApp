namespace Order.Application.Interfaces
{
    public interface IApplicationService<WriteDto, ReadDto>
    {
        Task CreateAsync(WriteDto writeDto);
        Task<IEnumerable<ReadDto>> GetAllAsync();
        Task<ReadDto> GetByIdAsync(Guid Id);
        Task DeleteAsync(Guid Id);
        Task UpdateAsync(WriteDto writeDto, Guid Id);
    }
}
