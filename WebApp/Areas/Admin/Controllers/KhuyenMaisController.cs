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
    public class KhuyenMaisController : Controller
    {
        private readonly DPContext _context;

        public KhuyenMaisController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/KhuyenMais
        public async Task<IActionResult> Index()
        {
            return View(await _context.KhuyenMai.ToListAsync());
        }

        // GET: Admin/KhuyenMais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai
                .FirstOrDefaultAsync(m => m.Makhuyenmai == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            return View(khuyenMai);
        }

        // GET: Admin/KhuyenMais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhuyenMais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makhuyenmai,Tenkhuyenmai,TrangThai")] KhuyenMai khuyenMai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khuyenMai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khuyenMai);
        }

        // GET: Admin/KhuyenMais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai.FindAsync(id);
            if (khuyenMai == null)
            {
                return NotFound();
            }
            return View(khuyenMai);
        }

        // POST: Admin/KhuyenMais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Makhuyenmai,Tenkhuyenmai,TrangThai")] KhuyenMai khuyenMai)
        {
            if (id != khuyenMai.Makhuyenmai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khuyenMai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenMaiExists(khuyenMai.Makhuyenmai))
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
            return View(khuyenMai);
        }

        // GET: Admin/KhuyenMais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai
                .FirstOrDefaultAsync(m => m.Makhuyenmai == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            return View(khuyenMai);
        }

        // POST: Admin/KhuyenMais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khuyenMai = await _context.KhuyenMai.FindAsync(id);
            _context.KhuyenMai.Remove(khuyenMai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhuyenMaiExists(int id)
        {
            return _context.KhuyenMai.Any(e => e.Makhuyenmai == id);
        }
    }
}
