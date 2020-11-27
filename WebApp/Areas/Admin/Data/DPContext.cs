using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Data
{
    public class DPContext:DbContext
    {
        public DPContext(DbContextOptions<DPContext> options)
            : base(options)
        {

        }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<LoaiSP> LoaiSP { get; set; }
        public DbSet<NhaCungCap> NhaCC { get; set; }
        public DbSet<WebApp.Areas.Admin.Models.NguoiDung> NguoiDung { get; set; }
    }
}
