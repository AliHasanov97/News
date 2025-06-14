using SonXeber.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonXeber.Application.Interfaces
{
    public interface INewsService
    {
        Task<List<NewsDto>> GetAllAsync();
        Task<NewsDto?> GetByIdAsync(Guid id);
        Task AddAsync(NewsDto dto);
        Task UpdateAsync(NewsDto dto);
        Task DeleteAsync(Guid id);
    }
}
