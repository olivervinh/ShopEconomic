using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBanHang.Areas.Admin.Models
{
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Tên sản phẩm")]
        public string TenSanPham { get; set; }
        [DisplayName("Tên Hình")]
        public IFormFile Hinh { get; set; }
        [DisplayName("Sản phẩm khuyến mãi")]
        public bool SanPhamKhuyenMai { get; set; }
        [DisplayName("Sản phẩm hot")]
        public bool SanPhamHot { get; set; }
        public bool Active { get; set; }
        [DisplayName("Giá ban đầu")]
        public long GiaBanDau { get; set; }
        [DisplayName("Giá hiện tại")]
        public long GiaHienTai { get; set; }
        [DisplayName("Ngày đăng")]
        public DateTime NgayDang { get; set; } = DateTime.Now;
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public virtual LoaiSanPham Loai { get; set; }


    }
}
