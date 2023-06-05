using AppData.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers;

public class NhanVienController : Controller
{
    private readonly HttpClient _client;
    private NhanVien _nhanVien;

    public NhanVienController()
    {
        _client = new HttpClient();
        _nhanVien = new NhanVien();
    }

    // GET
    public async Task<IActionResult> Show()
    {
        var url = "https://localhost:7195/api/NhanVien/get-all";
        var response = await _client.GetAsync(url);
        var result = await response.Content.ReadAsStringAsync();
        var nv = JsonConvert.DeserializeObject<IEnumerable<NhanVien>>(result);
        return View(nv);
    }

    //create

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NhanVien nhanvien)
    {
        if (ModelState.IsValid)
        {
            var url =
                $"https://localhost:7195/api/NhanVien/create?name={nhanvien.Name}&age={nhanvien.Age}&role={nhanvien.Age}&email={nhanvien.Email}&luong={nhanvien.Luong}&status={nhanvien.Status}";
            var response = await _client.PostAsync(url, null);
            if (response.IsSuccessStatusCode) return RedirectToAction("Show");
        }

        return View();
    }

    //edit
    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var url = $"https://localhost:7195/api/NhanVien/{id}";
        var response = _client.GetAsync(url).Result;
        var result = response.Content.ReadAsStringAsync().Result;
        var nv = JsonConvert.DeserializeObject<NhanVien>(result);
        return View(nv);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(NhanVien nhanvien)
    {
        if (ModelState.IsValid)
        {
            var url =
                $"https://localhost:7195/api/NhanVien/edit/{nhanvien.Id}?name={nhanvien.Name}&age={nhanvien.Age}&role={nhanvien.Age}&email={nhanvien.Email}&luong={nhanvien.Luong}&status={nhanvien.Status}";
            var response = await _client.PutAsync(url, null);
            if (response.IsSuccessStatusCode) return RedirectToAction("Show");
        }

        return View();
    }

    //delete
    public async Task<IActionResult> Delete(Guid id)
    {
        var url = $"https://localhost:7195/api/NhanVien/delete/{id}";
        var response = await _client.DeleteAsync(url);
        if (response.IsSuccessStatusCode) return RedirectToAction("Show");
        return BadRequest();
    }

    //detail
    public IActionResult Detail(Guid id)
    {
        var url = $"https://localhost:7195/api/NhanVien/{id}";
        var response = _client.GetAsync(url).Result;
        var result = response.Content.ReadAsStringAsync().Result;
        var nv = JsonConvert.DeserializeObject<NhanVien>(result);
        return View(nv);
    }
}