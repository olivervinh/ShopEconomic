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
    public class NhanVienQuanLisController : Controller
    {
        private readonly DPContext _context;

        public NhanVienQuanLisController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/NhanVienQuanLis
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.NhanVienQuanLi.Include(n => n.NguoiDung);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/NhanVienQuanLis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienQuanLi = await _context.NhanVienQuanLi
                .Include(n => n.NguoiDung)
                .FirstOrDefaultAsync(m => m.MaNVQuanLi == id);
            if (nhanVienQuanLi == null)
            {
                return NotFound();
            }

            return View(nhanVienQuanLi);
        }

        // GET: Admin/NhanVienQuanLis/Create
        public IActionResult Create()
        {
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau");
            return View();
        }

        // POST: Admin/NhanVienQuanLis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNVQuanLi,HinhDaiDien,HoTenNVQuanLi,NgaySinh,SDT,DiaChi,TrangThai,MaND")] NhanVienQuanLi nhanVienQuanLi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVienQuanLi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau", nhanVienQuanLi.MaND);
            return View(nhanVienQuanLi);
        }

        // GET: Admin/NhanVienQuanLis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienQuanLi = await _context.NhanVienQuanLi.FindAsync(id);
            if (nhanVienQuanLi == null)
            {
                return NotFound();
            }
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau", nhanVienQuanLi.MaND);
            return View(nhanVienQuanLi);
        }

        // POST: Admin/NhanVienQuanLis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNVQuanLi,HinhDaiDien,HoTenNVQuanLi,NgaySinh,SDT,DiaChi,TrangThai,MaND")] NhanVienQuanLi nhanVienQuanLi)
        {
            if (id != nhanVienQuanLi.MaNVQuanLi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVienQuanLi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienQuanLiExists(nhanVienQuanLi.MaNVQuanLi))
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
            ViewData["MaND"] = new SelectList(_context.NguoiDung, "MaNguoiDung", "MatKhau", nhanVienQuanLi.MaND);
            return View(nhanVienQuanLi);
        }

        // GET: Admin/NhanVienQuanLis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienQuanLi = await _context.NhanVienQuanLi
                .Include(n => n.NguoiDung)
                .FirstOrDefaultAsync(m => m.MaNVQuanLi == id);
            if (nhanVienQuanLi == null)
            {
                return NotFound();
            }

            return View(nhanVienQuanLi);
        }

        // POST: Admin/NhanVienQuanLis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVienQuanLi = await _context.NhanVienQuanLi.FindAsync(id);
            _context.NhanVienQuanLi.Remove(nhanVienQuanLi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienQuanLiExists(int id)
        {
            return _context.NhanVienQuanLi.Any(e => e.MaNVQuanLi == id);
        }
    }
}
