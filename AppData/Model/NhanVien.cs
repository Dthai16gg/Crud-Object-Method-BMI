using System.ComponentModel.DataAnnotations;

namespace AppData.Model;

public class NhanVien
{
    // Khoa chinh
    [Required(ErrorMessage = "Id khong duoc de trong")]
    public Guid Id { get; set; }

    //ten co toi da 30 ky tu
    [MaxLength(30, ErrorMessage = "Ten khong duoc qua 30 ky tu")]
    public string Name { get; set; }

    //Tuoi tu 18-50
    [Range(18, 50, ErrorMessage = "Tuoi phai tu 18-50")]
    public int Age { get; set; }

    //role
    [Required(ErrorMessage = "Role khong duoc de trong")] //khong duoc null
    public int Role { get; set; }

    //email dung dinh dang
    [EmailAddress(ErrorMessage = "Email khong dung dinh dang")]
    public string Email { get; set; }

    //Lương từ 5.000.000 đến 30.000.000
    [Range(5000000, 30000000, ErrorMessage = "Luong phai tu 5.000.000 den 30.000.000")]
    public int Luong { get; set; }

    //trang thai
    [Required(ErrorMessage = "Status khong duoc de trong")]
    public bool Status { get; set; }
}