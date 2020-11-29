using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Areas.Admin.Models
{
    public class NhaCungCap
    {
        [Key]
        public int Id{ get; set; }
        [DisplayName("Tên nhà cung cấp")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên loại sản phẩm không được để trống")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 30 kí tự")]

        public string TenNCC { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên địa chỉ NCC không được để trống")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 30 kí tự")]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "SĐT không được để trống")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "Độ dài chuỗi từ 9 đến 11 kí tự")]
        [DisplayName("Số điện thoại")]
        public string SĐT { get; set; }
        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public int TrangThai { get; set; } = 1; //defualt TrangThai = 1
        public ICollection<SanPham> LstSanPham { get; set; }
    }
}
