using Microsoft.AspNetCore.Mvc;
using SonXeber.WebUI.ViewModels;
using System.Net.Http.Json;

namespace SonXeber.WebUI.Controllers;

public class NewsController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public NewsController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient("NewsApi");
        var newsList = await client.GetFromJsonAsync<List<NewsViewModel>>("news");
        return View(newsList);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(NewsViewModel model)
    {
        var client = _clientFactory.CreateClient("NewsApi");
        var response = await client.PostAsJsonAsync("news", model);
        if (response.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View(model);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var client = _clientFactory.CreateClient("NewsApi");
        var item = await client.GetFromJsonAsync<NewsViewModel>($"news/{id}");
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, NewsViewModel model)
    {
        var client = _clientFactory.CreateClient("NewsApi");
        var response = await client.PutAsJsonAsync($"news/{id}", model);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var client = _clientFactory.CreateClient("NewsApi");
        var item = await client.GetFromJsonAsync<NewsViewModel>($"news/{id}");
        if (item == null)
            return NotFound();
        return View(item);
    }


    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var client = _clientFactory.CreateClient("NewsApi");
        await client.DeleteAsync($"news/{id}");
        return RedirectToAction("Index");
    }

}
