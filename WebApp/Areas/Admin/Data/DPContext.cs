using Microsoft.EntityFrameworkCore;
using ShopBanHang.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApp.Areas.Admin.Data
{
    public class DPContext:DbContext
    {
        public DPContext(DbContextOptions<DPContext> options)
            : base(options)
        {

        }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<LoaiSanPham> LoaiSP { get; set; }
      
    }
}
