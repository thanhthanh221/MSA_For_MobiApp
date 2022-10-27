using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Interfaces
{
    public interface IApplicationService<ReadDto, WriteDto>
    {
        Task CreateAsync(WriteDto writeDto);
        Task<IEnumerable<ReadDto>> GetAllAsync();
        Task<ReadDto> GetByIdAsync(Guid Id);
        Task DeleteAsync(Guid Id);
        Task UpdateAsync(WriteDto writeDto, Guid Id);
    }
}
