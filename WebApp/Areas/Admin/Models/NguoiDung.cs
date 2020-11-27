using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }

    }
}
