using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Areas.Admin.Models
{
    public class ChuDe
    {
        [Key]
        public int MaChuDe { get; set; }

        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [DisplayName("Tên chủ đề:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên chủ đề không được để trống ")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 60 kí tự")]
        public string Tenchude { get; set; }
        
        [DisplayName("Mô tả:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mô tả không được để trống ")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Độ dài chuỗi từ 3 đến 60 kí tự")]
        public string MoTa { get; set; }
       
       
        [DefaultValue(true)]
        public int TrangThai { get; set; } = 1;
        public ICollection<TinTuc> LstTinTuc { get; set; }
        

    }
}
