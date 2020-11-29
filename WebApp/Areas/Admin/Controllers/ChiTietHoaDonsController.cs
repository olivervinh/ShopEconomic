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
    public class ChiTietHoaDonsController : Controller
    {
        private readonly DPContext _context;

        public ChiTietHoaDonsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/ChiTietHoaDons
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.ChiTietHoaDon.Include(c => c.HoaDon).Include(c => c.SanPham);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/ChiTietHoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDon
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.MaCTHD == id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDon);
        }

        // GET: Admin/ChiTietHoaDons/Create
        public IActionResult Create()
        {
            ViewData["MaHD"] = new SelectList(_context.Set<HoaDon>(), "MaHD", "MaHD");
            ViewData["MaSP"] = new SelectList(_context.SanPham, "MaSanPham", "MoTa");
            return View();
        }

        // POST: Admin/ChiTietHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCTHD,Soluong,Thanhtien,TrangThai,MaHD,MaSP")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHD"] = new SelectList(_context.Set<HoaDon>(), "MaHD", "MaHD", chiTietHoaDon.MaHD);
            ViewData["MaSP"] = new SelectList(_context.SanPham, "MaSanPham", "MoTa", chiTietHoaDon.MaSP);
            return View(chiTietHoaDon);
        }

        // GET: Admin/ChiTietHoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDon.FindAsync(id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }
            ViewData["MaHD"] = new SelectList(_context.Set<HoaDon>(), "MaHD", "MaHD", chiTietHoaDon.MaHD);
            ViewData["MaSP"] = new SelectList(_context.SanPham, "MaSanPham", "MoTa", chiTietHoaDon.MaSP);
            return View(chiTietHoaDon);
        }

        // POST: Admin/ChiTietHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCTHD,Soluong,Thanhtien,TrangThai,MaHD,MaSP")] ChiTietHoaDon chiTietHoaDon)
        {
            if (id != chiTietHoaDon.MaCTHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHoaDonExists(chiTietHoaDon.MaCTHD))
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
            ViewData["MaHD"] = new SelectList(_context.Set<HoaDon>(), "MaHD", "MaHD", chiTietHoaDon.MaHD);
            ViewData["MaSP"] = new SelectList(_context.SanPham, "MaSanPham", "MoTa", chiTietHoaDon.MaSP);
            return View(chiTietHoaDon);
        }

        // GET: Admin/ChiTietHoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDon
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.MaCTHD == id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDon);
        }

        // POST: Admin/ChiTietHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietHoaDon = await _context.ChiTietHoaDon.FindAsync(id);
            _context.ChiTietHoaDon.Remove(chiTietHoaDon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHoaDonExists(int id)
        {
            return _context.ChiTietHoaDon.Any(e => e.MaCTHD == id);
        }
    }
}
