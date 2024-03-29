﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairSalon.Data;

namespace HairSalon.Controllers
{
    public class ArticulsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articuls
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Articuls.Include(a => a.Categories);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Articuls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articul = await _context.Articuls
                .Include(a => a.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articul == null)
            {
                return NotFound();
            }

            return View(articul);
        }

        // GET: Articuls/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Articuls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Manifacture,Description,CategoryId,Price,ImageURL,RegisterOn")] Articul articul)
        {
            articul.RegisterOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Articuls.Add(articul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", articul.CategoryId);
            return View(articul);
        }

        // GET: Articuls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articul = await _context.Articuls.FindAsync(id);
            if (articul == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", articul.CategoryId);
            return View(articul);
        }

        // POST: Articuls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Manifacture,Description,CategoryId,Price,ImageURL,RegisterOn")] Articul articul)
        {
            if (id != articul.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    articul.RegisterOn = DateTime.Now;
                    _context.Articuls.Update(articul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticulExists(articul.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", articul.CategoryId);
            return View(articul);
        }

        // GET: Articuls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articul = await _context.Articuls
                .Include(a => a.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articul == null)
            {
                return NotFound();
            }

            return View(articul);
        }

        // POST: Articuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articul = await _context.Articuls.FindAsync(id);
            if (articul != null)
            {
                _context.Articuls.Remove(articul);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticulExists(int id)
        {
            return _context.Articuls.Any(e => e.Id == id);
        }
    }
}
