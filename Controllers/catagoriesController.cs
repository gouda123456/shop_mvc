using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shop_mvc.Models;

namespace shop_mvc.Controllers
{
    public class catagoriesController : Controller
    {
        private readonly context _context;

        public catagoriesController(context context)
        {
            _context = context;
        }

        // GET: catagories
        [Authorize(Roles = role.user)]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catagories.ToListAsync());
        }

        // GET: catagories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }

            return View(catagory);
        }

        // GET: catagories/Create
        [Authorize(Roles = role.admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: catagories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = role.admin)]
        
        public async Task<IActionResult> Create(catagory catagory)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(catagory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catagory);
        }

        // GET: catagories/Edit/5
        [Authorize(Roles = role.admin)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagories.FindAsync(id);
            if (catagory == null)
            {
                return NotFound();
            }
            return View(catagory);
        }

        // POST: catagories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = role.admin)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] catagory catagory)
        {
            if (id != catagory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catagory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!catagoryExists(catagory.Id))
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
            return View(catagory);
        }

        // GET: catagories/Delete/5
        [Authorize(Roles = role.admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }

            return View(catagory);
        }

        // POST: catagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = role.admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catagory = await _context.Catagories.FindAsync(id);
            if (catagory != null)
            {
                _context.Catagories.Remove(catagory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool catagoryExists(int id)
        {
            return _context.Catagories.Any(e => e.Id == id);
        }
        [ActionName("fuck")]
        public IActionResult fuck(int id)
        {
            return View();
        }
        [ActionName("fuck")]
        public IActionResult fuck2(int id)
        {
           
            return View();
        }
    }
}
