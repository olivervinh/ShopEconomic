using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Areas.Admin.Models
{
    public class LoaiSP
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Tên loại sản phẩm")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên loại sản phẩm không được để trống")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 30 kí tự")]
        public string TenloaiSP { get; set; }
        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public int TrangThai { get; set; } = 1; //defualt TrangThai = 1 
        public ICollection<SanPham> LstSanPham { get; set; }

    }
}
