using Microsoft.AspNetCore.Mvc;

namespace AppView.Controllers;

public class BmiController : Controller
{
    // GET
    private readonly HttpClient _httpClient;

    public BmiController()
    {
        _httpClient = new HttpClient();
    }

    public async Task<IActionResult> Calculate(double weight, double height)
    {
        var url = $"https://localhost:7195/api/Bmi/{weight}/{height}";
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            ViewBag.Bmi = result;
        }

        return View();
    }
}