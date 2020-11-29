using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Areas.Admin.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }
      
        [Display(Name = "Ngày lập ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Ngaylap { get; set; } = DateTime.Now;
        [DisplayName("Giảm giá: ")]
        public int GiamGia { get; set; }
        [DisplayName("Tổng tiền:  ")]
        public long TongTien { get; set; }
        [DefaultValue(true)]
        public int TrangThai { get; set; } = 1;
        [DisplayName("Tên khách hàng:")]
        public int MaKH { get; set; }
        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }
        [DisplayName("Khuyến mãi:")]
        public int MaKhuyenMai { get; set; }
        [ForeignKey("MaKhuyenMai")]
        public virtual KhuyenMai KhuyenMai { get; set; }
        public ICollection<HoaDon> LstHoaHon { get; set; }
    }
}
