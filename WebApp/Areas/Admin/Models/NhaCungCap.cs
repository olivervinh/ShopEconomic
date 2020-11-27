using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class NhaCungCap
    {
        [Key]
        public int Id{ get; set; }
        [DisplayName("Tên nhà cung cấp")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên loại sản phẩm không được để trống")]
        [StringLength(maximumLength: 191, MinimumLength = 1, ErrorMessage = "Độ dài chuỗi từ 1 đến 191 kí tự")]

        public string TenNCC { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên địa chỉ NCC không được để trống")]
        [StringLength(maximumLength: 191, MinimumLength = 1, ErrorMessage = "Độ dài chuỗi từ 1 đến 191 kí tự")]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "SĐT không được để trống")]
        [StringLength(maximumLength: 11, MinimumLength = 1, ErrorMessage = "Độ dài chuỗi từ 1 đến 191 kí tự")]
        [DisplayName("Số điện thoại")]
        public string SĐT { get; set; }
        [DisplayName("Trạng thái")]
        public int TrangThai { get; set; } = 1; //defualt TrangThai = 1
        public ICollection<SanPham> LstSanPham { get; set; }
    }
}
