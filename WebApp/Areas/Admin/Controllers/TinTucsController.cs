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
    public class TinTucsController : Controller
    {
        private readonly DPContext _context;

        public TinTucsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/TinTucs
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.TinTuc.Include(t => t.ChuDe).Include(t => t.NhanVienQuanLi);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/TinTucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTuc
                .Include(t => t.ChuDe)
                .Include(t => t.NhanVienQuanLi)
                .FirstOrDefaultAsync(m => m.MaTinTuc == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Create
        public IActionResult Create()
        {
            ViewData["MaChuDe"] = new SelectList(_context.ChuDe, "MaChuDe", "MoTa");
            ViewData["Matacgia"] = new SelectList(_context.NhanVienQuanLi, "MaNVQuanLi", "DiaChi");
            return View();
        }

        // POST: Admin/TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTinTuc,HinhDaiDien,Tentieude,NgayDang,MoTa,TrangThai,Matacgia,MaChuDe")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinTuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChuDe"] = new SelectList(_context.ChuDe, "MaChuDe", "MoTa", tinTuc.MaChuDe);
            ViewData["Matacgia"] = new SelectList(_context.NhanVienQuanLi, "MaNVQuanLi", "DiaChi", tinTuc.Matacgia);
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTuc.FindAsync(id);
            if (tinTuc == null)
            {
                return NotFound();
            }
            ViewData["MaChuDe"] = new SelectList(_context.ChuDe, "MaChuDe", "MoTa", tinTuc.MaChuDe);
            ViewData["Matacgia"] = new SelectList(_context.NhanVienQuanLi, "MaNVQuanLi", "DiaChi", tinTuc.Matacgia);
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTinTuc,HinhDaiDien,Tentieude,NgayDang,MoTa,TrangThai,Matacgia,MaChuDe")] TinTuc tinTuc)
        {
            if (id != tinTuc.MaTinTuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinTuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinTucExists(tinTuc.MaTinTuc))
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
            ViewData["MaChuDe"] = new SelectList(_context.ChuDe, "MaChuDe", "MoTa", tinTuc.MaChuDe);
            ViewData["Matacgia"] = new SelectList(_context.NhanVienQuanLi, "MaNVQuanLi", "DiaChi", tinTuc.Matacgia);
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTuc
                .Include(t => t.ChuDe)
                .Include(t => t.NhanVienQuanLi)
                .FirstOrDefaultAsync(m => m.MaTinTuc == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tinTuc = await _context.TinTuc.FindAsync(id);
            _context.TinTuc.Remove(tinTuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinTucExists(int id)
        {
            return _context.TinTuc.Any(e => e.MaTinTuc == id);
        }
    }
}
