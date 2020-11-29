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
    public class HoaDonsController : Controller
    {
        private readonly DPContext _context;

        public HoaDonsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/HoaDons
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.HoaDon.Include(h => h.KhachHang).Include(h => h.KhuyenMai);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/HoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDon
                .Include(h => h.KhachHang)
                .Include(h => h.KhuyenMai)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Create
        public IActionResult Create()
        {
            ViewData["MaKH"] = new SelectList(_context.Set<KhachHang>(), "MaNVBan", "DiaChi");
            ViewData["MaKhuyenMai"] = new SelectList(_context.Set<KhuyenMai>(), "Makhuyenmai", "Tenkhuyenmai");
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHD,Ngaylap,GiamGia,TongTien,TrangThai,MaKH,MaKhuyenMai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKH"] = new SelectList(_context.Set<KhachHang>(), "MaNVBan", "DiaChi", hoaDon.MaKH);
            ViewData["MaKhuyenMai"] = new SelectList(_context.Set<KhuyenMai>(), "Makhuyenmai", "Tenkhuyenmai", hoaDon.MaKhuyenMai);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDon.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            ViewData["MaKH"] = new SelectList(_context.Set<KhachHang>(), "MaNVBan", "DiaChi", hoaDon.MaKH);
            ViewData["MaKhuyenMai"] = new SelectList(_context.Set<KhuyenMai>(), "Makhuyenmai", "Tenkhuyenmai", hoaDon.MaKhuyenMai);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHD,Ngaylap,GiamGia,TongTien,TrangThai,MaKH,MaKhuyenMai")] HoaDon hoaDon)
        {
            if (id != hoaDon.MaHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.MaHD))
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
            ViewData["MaKH"] = new SelectList(_context.Set<KhachHang>(), "MaNVBan", "DiaChi", hoaDon.MaKH);
            ViewData["MaKhuyenMai"] = new SelectList(_context.Set<KhuyenMai>(), "Makhuyenmai", "Tenkhuyenmai", hoaDon.MaKhuyenMai);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDon
                .Include(h => h.KhachHang)
                .Include(h => h.KhuyenMai)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDon = await _context.HoaDon.FindAsync(id);
            _context.HoaDon.Remove(hoaDon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(int id)
        {
            return _context.HoaDon.Any(e => e.MaHD == id);
        }
    }
}
