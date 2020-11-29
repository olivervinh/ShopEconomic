using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Areas.Admin.Models
{
    public class KhuyenMai
    {
        [Key]
        public int Makhuyenmai { get; set; }
        [DisplayName("Tên khuyến mãi:  ")]
        [DefaultValue(true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên tài khoản không được để trống ")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 60 kí tự")]
        public string Tenkhuyenmai { get; set; } = "Khuyến mãi theo tổng hóa đơn";
       
        [DefaultValue(true)]
        public int TrangThai { get; set; } = 1;
        public ICollection<HoaDon> LstHoaHon { get; set; }

    }
}
