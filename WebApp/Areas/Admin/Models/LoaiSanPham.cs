using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBanHang.Areas.Admin.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int MaLoai { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Tên loại")]
        public string TenLoai { get; set; }
        public ICollection<SanPham> LstSanPham { get; set; }
    }
}
