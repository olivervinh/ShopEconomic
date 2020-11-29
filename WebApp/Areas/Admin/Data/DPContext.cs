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
        public DbSet<WebApp.Areas.Admin.Models.ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<WebApp.Areas.Admin.Models.ChuDe> ChuDe { get; set; }
        public DbSet<WebApp.Areas.Admin.Models.HoaDon> HoaDon { get; set; }
        public DbSet<WebApp.Areas.Admin.Models.KhachHang> KhachHang { get; set; }
        public DbSet<WebApp.Areas.Admin.Models.KhuyenMai> KhuyenMai { get; set; }
        public DbSet<WebApp.Areas.Admin.Models.NhanVienBanHang> NhanVienBanHang { get; set; }
        public DbSet<WebApp.Areas.Admin.Models.NhanVienGiaoHang> NhanVienGiaoHang { get; set; }
        public DbSet<WebApp.Areas.Admin.Models.NhanVienQuanLi> NhanVienQuanLi { get; set; }
        public DbSet<WebApp.Areas.Admin.Models.TinTuc> TinTuc { get; set; }
    }
}
