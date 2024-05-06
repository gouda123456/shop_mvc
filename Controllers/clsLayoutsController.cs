using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shop_mvc.Models;

namespace shop_mvc.Controllers
{
    public class clsLayoutsController : Controller
    {
        private readonly context _context;

        public clsLayoutsController(context context)
        {
            _context = context;
        }

        // GET: clsLayouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.clsLayout.ToListAsync());
        }

        // GET: clsLayouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsLayout = await _context.clsLayout
                .FirstOrDefaultAsync(m => m.id == id);
            if (clsLayout == null)
            {
                return NotFound();
            }

            return View(clsLayout);
        }

        // GET: clsLayouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: clsLayouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description")] clsLayout clsLayout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clsLayout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clsLayout);
        }

        // GET: clsLayouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsLayout = await _context.clsLayout.FindAsync(id);
            if (clsLayout == null)
            {
                return NotFound();
            }
            return View(clsLayout);
        }

        // POST: clsLayouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description")] clsLayout clsLayout)
        {
            if (id != clsLayout.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clsLayout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!clsLayoutExists(clsLayout.id))
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
            return View(clsLayout);
        }

        // GET: clsLayouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsLayout = await _context.clsLayout
                .FirstOrDefaultAsync(m => m.id == id);
            if (clsLayout == null)
            {
                return NotFound();
            }

            return View(clsLayout);
        }

        // POST: clsLayouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clsLayout = await _context.clsLayout.FindAsync(id);
            if (clsLayout != null)
            {
                _context.clsLayout.Remove(clsLayout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool clsLayoutExists(int id)
        {
            return _context.clsLayout.Any(e => e.id == id);
        }
    }
}
