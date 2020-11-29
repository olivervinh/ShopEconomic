using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Areas.Admin.Models
{
    public class NguoiDung
    {
        [Key]

        public int MaNguoiDung { get; set; }
        [DisplayName("Tên tài khoản")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên tài khoản không được để trống ")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 30 kí tự")]
        public string TenTaiKhoan { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Mật khẩu tối đa 6 đến 100 kí tự  ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string MatKhau { get; set; }
    
        public int PhanQuyen { get; set; }
        [DefaultValue(true)]
        public int TrangThai { get; set; } = 1;
        public ICollection<NhanVienBanHang> LstNVBan { get; set; }
        public ICollection<NhanVienGiaoHang> LstNVGiao { get; set; }
        public ICollection<NhanVienQuanLi> LstNVQuanli { get; set; }
        public ICollection<KhachHang> LstKH { get; set; }
    }
}
