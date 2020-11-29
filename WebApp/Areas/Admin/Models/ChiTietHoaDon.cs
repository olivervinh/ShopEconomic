using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Areas.Admin.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaCTHD { get; set; }

       
        [DisplayName("Số lượng:")]
        public int Soluong { get; set; }
        [DisplayName("Thành tiền:")]
        public long Thanhtien{ get; set; }
        [DefaultValue(true)]
        public int TrangThai { get; set; } = 1;

        [DisplayName("Mã hóa đơn:")]
        public int MaHD { get; set; }
        [ForeignKey("MaHD")]

        public virtual HoaDon HoaDon { get; set; }
        [DisplayName("Tên sản phẩm:")]
        public int MaSP { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }


    }
}
