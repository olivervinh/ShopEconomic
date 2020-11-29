using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Areas.Admin.Models
{
    public class TinTuc
    {
        [Key]
        public int MaTinTuc { get; set; }
       
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [DisplayName("Tiêu đề:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên tiêu đề không được để trống ")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 60 kí tự")]
        public string Tentieude { get; set; }
        [Display(Name = "Ngày đăng: ")]
        [DefaultValue(true)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime NgayDang { get; set; } = DateTime.Now;
        [DisplayName("Mô tả:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mô tả không được để trống ")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 60 kí tự")]
        public string MoTa { get; set; }
        [DisplayName("Nội dung chi tiết :  ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nội dung chi tiết không được để trống ")]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Độ dài chuỗi từ 20 đến 1000 kí tự")]
        
        public int TrangThai { get; set; } = 1;
        [DisplayName("Tên tác giả: ")]
        public int Matacgia { get; set; }
        [ForeignKey("Matacgia")]
        public virtual NhanVienQuanLi NhanVienQuanLi { get; set; }
        [DisplayName("Tên chủ đề: ")]
        public int MaChuDe { get; set; }
        [ForeignKey("MaChuDe")]
        public virtual ChuDe ChuDe { get; set; }

    }
}
