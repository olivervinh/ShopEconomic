using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Admin.Data;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhanVienBanHangsController : Controller
    {
        private readonly DPContext _context;

        public NhanVienBanHangsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/NhanVienBanHangs
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.NhanVienBanHang.Include(n => n.NguoiDung);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/NhanVienBanHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienBanHang = await _context.NhanVienBanHang
                .Include(n => n.NguoiDung)
                .FirstOrDefaultAsync(m => m.MaNVBan == id);
            if (nhanVienBanHang == null)
            {
                return NotFound();
            }

            return View(nhanVienBanHang);
        }

        // GET: Admin/NhanVienBanHangs/Create
        public IActionResult Create()
        {
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau");
            return View();
        }

        // POST: Admin/NhanVienBanHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNVBan,HinhDaiDien,HoTenNVBan,NgaySinh,SDT,DiaChi,TrangThai,MaND")] NhanVienBanHang nhanVienBanHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVienBanHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau", nhanVienBanHang.MaND);
            return View(nhanVienBanHang);
        }

        // GET: Admin/NhanVienBanHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienBanHang = await _context.NhanVienBanHang.FindAsync(id);
            if (nhanVienBanHang == null)
            {
                return NotFound();
            }
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau", nhanVienBanHang.MaND);
            return View(nhanVienBanHang);
        }

        // POST: Admin/NhanVienBanHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNVBan,HinhDaiDien,HoTenNVBan,NgaySinh,SDT,DiaChi,TrangThai,MaND")] NhanVienBanHang nhanVienBanHang)
        {
            if (id != nhanVienBanHang.MaNVBan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVienBanHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienBanHangExists(nhanVienBanHang.MaNVBan))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau", nhanVienBanHang.MaND);
            return View(nhanVienBanHang);
        }

        // GET: Admin/NhanVienBanHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienBanHang = await _context.NhanVienBanHang
                .Include(n => n.NguoiDung)
                .FirstOrDefaultAsync(m => m.MaNVBan == id);
            if (nhanVienBanHang == null)
            {
                return NotFound();
            }

            return View(nhanVienBanHang);
        }

        // POST: Admin/NhanVienBanHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVienBanHang = await _context.NhanVienBanHang.FindAsync(id);
            _context.NhanVienBanHang.Remove(nhanVienBanHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienBanHangExists(int id)
        {
            return _context.NhanVienBanHang.Any(e => e.MaNVBan == id);
        }
    }
}
