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
    public class NhanVienGiaoHangsController : Controller
    {
        private readonly DPContext _context;

        public NhanVienGiaoHangsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/NhanVienGiaoHangs
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.NhanVienGiaoHang.Include(n => n.NguoiDung);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/NhanVienGiaoHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienGiaoHang = await _context.NhanVienGiaoHang
                .Include(n => n.NguoiDung)
                .FirstOrDefaultAsync(m => m.MaNVGiao == id);
            if (nhanVienGiaoHang == null)
            {
                return NotFound();
            }

            return View(nhanVienGiaoHang);
        }

        // GET: Admin/NhanVienGiaoHangs/Create
        public IActionResult Create()
        {
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau");
            return View();
        }

        // POST: Admin/NhanVienGiaoHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNVGiao,HinhDaiDien,HoTenNVGiao,NgaySinh,SDT,DiaChi,TrangThai,MaND")] NhanVienGiaoHang nhanVienGiaoHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVienGiaoHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau", nhanVienGiaoHang.MaND);
            return View(nhanVienGiaoHang);
        }

        // GET: Admin/NhanVienGiaoHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienGiaoHang = await _context.NhanVienGiaoHang.FindAsync(id);
            if (nhanVienGiaoHang == null)
            {
                return NotFound();
            }
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau", nhanVienGiaoHang.MaND);
            return View(nhanVienGiaoHang);
        }

        // POST: Admin/NhanVienGiaoHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNVGiao,HinhDaiDien,HoTenNVGiao,NgaySinh,SDT,DiaChi,TrangThai,MaND")] NhanVienGiaoHang nhanVienGiaoHang)
        {
            if (id != nhanVienGiaoHang.MaNVGiao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVienGiaoHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienGiaoHangExists(nhanVienGiaoHang.MaNVGiao))
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
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau", nhanVienGiaoHang.MaND);
            return View(nhanVienGiaoHang);
        }

        // GET: Admin/NhanVienGiaoHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienGiaoHang = await _context.NhanVienGiaoHang
                .Include(n => n.NguoiDung)
                .FirstOrDefaultAsync(m => m.MaNVGiao == id);
            if (nhanVienGiaoHang == null)
            {
                return NotFound();
            }

            return View(nhanVienGiaoHang);
        }

        // POST: Admin/NhanVienGiaoHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVienGiaoHang = await _context.NhanVienGiaoHang.FindAsync(id);
            _context.NhanVienGiaoHang.Remove(nhanVienGiaoHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienGiaoHangExists(int id)
        {
            return _context.NhanVienGiaoHang.Any(e => e.MaNVGiao == id);
        }
    }
}
