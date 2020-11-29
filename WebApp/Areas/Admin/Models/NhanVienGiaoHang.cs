using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Areas.Admin.Models
{
    public class NhanVienGiaoHang
    {
        [Key]
        public int MaNVGiao { get; set; }

        public string HinhDaiDien { get; set; }
        [DisplayName("Họ tên nhân viên giao hàng:  ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên tài khoản không được để trống ")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 30 kí tự")]
        [Display(Name = "Hình đại diện")]
        public string HoTenNVGiao { get; set; }
        [Display(Name = "Ngày sinh")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ngày sinh không được để trống ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }
        [DisplayName("Số điện thoại:  ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên tài khoản không được để trống ")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "Độ dài chuỗi từ 9 đến 11 kí tự")]
        public string SDT { get; set; }
        [DisplayName("Địa chỉ:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Địa chỉ không được để trống ")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 60 kí tự")]
        public string DiaChi { get; set; }
        [DefaultValue(true)]
        public int TrangThai { get; set; } = 1;
        [DisplayName("Mã người dùng:")]
        public int MaND { get; set; }
        [ForeignKey("MaND")]
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
