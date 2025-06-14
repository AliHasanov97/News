using SonXeber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonXeber.Domain.Interfaces
{
    public interface INewsRepository
    {
        Task<List<News>> GetAllAsync();
        Task<News?> GetByIdAsync(Guid id);
        Task AddAsync(News news);
        Task UpdateAsync(News news);
        Task DeleteAsync(Guid id);
    }
}
