using AppData.DbContext;
using AppData.Model;
using AppData.Responstories;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NhanVienController : Controller
{
    private readonly Db_context _dbContext = new();
    private readonly IRespon<NhanVien> _respon;

    public NhanVienController()
    {
        var _nhanVien = new Respon<NhanVien>(_dbContext, _dbContext.NhanViens);
        _respon = _nhanVien;
    }

    //show
    [HttpGet("get-all")]
    public IEnumerable<NhanVien> Get()
    {
        return _respon.GetAll();
    }

    //show by id
    [HttpGet("{id}")]
    public NhanVien Get(Guid id)
    {
        return _respon.GetOne(id);
    }

    //create
    [HttpPost("create")]
    public string Post(string name, int age, int role, string email, int luong, bool status)
    {
        var nhanVien = new NhanVien();
        nhanVien.Id = Guid.NewGuid();
        nhanVien.Name = name;
        nhanVien.Age = age;
        nhanVien.Role = role;
        nhanVien.Email = email;
        nhanVien.Luong = luong;
        nhanVien.Status = status;
        return _respon.Create(nhanVien);
    }

    //edit
    [HttpPut("edit/{id}")]
    public string Put(Guid id, string name, int age, int role, string email, int luong, bool status)
    {
        var nhanVien = _respon.GetAll().FirstOrDefault(p => p.Id == id);
        nhanVien.Name = name;
        nhanVien.Age = age;
        nhanVien.Role = role;
        nhanVien.Email = email;
        nhanVien.Luong = luong;
        nhanVien.Status = status;
        return _respon.Update(nhanVien);
    }

    //delete
    [HttpDelete("delete/{id}")]
    public string Delete(Guid id)
    {
        return _respon.Delete(_respon.GetAll().FirstOrDefault(p => p.Id == id));
    }
}