// Repositories/NewsRepository.cs
using Microsoft.EntityFrameworkCore;
using SonXeber.Domain.Entities;
using SonXeber.Domain.Interfaces;
using SonXeber.Infrastructure.Data;

namespace SonXeber.Infrastructure.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly AppDbContext _context;

    public NewsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<News>> GetAllAsync()
    {
        return await _context.News
            .OrderByDescending(n => n.PublishedDate)
            .ToListAsync();
    }

    public async Task<News?> GetByIdAsync(Guid id)
    {
        return await _context.News.FindAsync(id);
    }

    public async Task AddAsync(News news)
    {
        _context.News.Add(news);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(News news)
    {
        _context.News.Update(news);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var news = await _context.News.FindAsync(id);
        if (news != null)
        {
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
        }
    }
}
