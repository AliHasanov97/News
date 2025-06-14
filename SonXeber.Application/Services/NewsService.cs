// Services/NewsService.cs

using SonXeber.Application.DTOs;
using SonXeber.Application.Interfaces;
using SonXeber.Domain.Entities;
using SonXeber.Domain.Interfaces;

namespace SonXeber.Application.Services;

public class NewsService : INewsService
{
    private readonly INewsRepository _repo;

    public NewsService(INewsRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<NewsDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return list.Select(n => new NewsDto
        {
            Id = n.Id,
            Title = n.Title,
            Content = n.Content,
            PublishedDate = n.PublishedDate
        }).ToList();
    }

    public async Task<NewsDto?> GetByIdAsync(Guid id)
    {
        var n = await _repo.GetByIdAsync(id);
        return n == null ? null : new NewsDto
        {
            Id = n.Id,
            Title = n.Title,
            Content = n.Content,
            PublishedDate = n.PublishedDate
        };
    }

    public async Task AddAsync(NewsDto dto)
    {
        var news = new News
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Content = dto.Content,
            PublishedDate = dto.PublishedDate
        };
        await _repo.AddAsync(news);
    }

    public async Task UpdateAsync(NewsDto dto)
    {
        var news = new News
        {
            Id = dto.Id,
            Title = dto.Title,
            Content = dto.Content,
            PublishedDate = dto.PublishedDate
        };
        await _repo.UpdateAsync(news);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
    }
}
