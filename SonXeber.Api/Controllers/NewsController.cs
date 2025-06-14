// Controllers/NewsController.cs
using Microsoft.AspNetCore.Mvc;
using SonXeber.Application.DTOs;
using SonXeber.Application.Interfaces;

namespace SonXeber.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var news = await _newsService.GetAllAsync();
        return Ok(news);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var item = await _newsService.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewsDto dto)
    {
        await _newsService.AddAsync(dto);
        return Ok(new { message = "Xəbər əlavə edildi." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] NewsDto dto)
    {
        dto.Id = id;
        await _newsService.UpdateAsync(dto);
        return Ok(new { message = "Xəbər yeniləndi." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _newsService.DeleteAsync(id);
        return Ok(new { message = "Xəbər silindi." });
    }
}
