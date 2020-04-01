using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Data;
using SacramentPlanner.Models;

namespace SacramentPlanner.Controllers
{
    public class DirectoriesController : Controller
    {
        private readonly SacramentPlannerContext _context;

        public DirectoriesController(SacramentPlannerContext context)
        {
            _context = context;
        }

        // GET: Directories
        public async Task<IActionResult> Index()
        {
            var sacramentPlannerContext = _context.Directory.Include(d => d.Ward);
            return View(await sacramentPlannerContext.ToListAsync());
        }

        // GET: Directories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directory = await _context.Directory
                .Include(d => d.Ward)
                .FirstOrDefaultAsync(m => m.DirectoryID == id);
            if (directory == null)
            {
                return NotFound();
            }

            return View(directory);
        }

        // GET: Directories/Create
        public IActionResult Create()
        {
            ViewData["WardID"] = new SelectList(_context.Ward, "WardID", "WardID");
            return View();
        }

        // POST: Directories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectoryID,WardID,First_Name,Last_Name,Age,Sex,Calling")] Directory directory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WardID"] = new SelectList(_context.Ward, "WardID", "WardID", directory.WardID);
            return View(directory);
        }

        // GET: Directories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directory = await _context.Directory.FindAsync(id);
            if (directory == null)
            {
                return NotFound();
            }
            ViewData["WardID"] = new SelectList(_context.Ward, "WardID", "WardID", directory.WardID);
            return View(directory);
        }

        // POST: Directories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectoryID,WardID,First_Name,Last_Name,Age,Sex,Calling")] Directory directory)
        {
            if (id != directory.DirectoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryExists(directory.DirectoryID))
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
            ViewData["WardID"] = new SelectList(_context.Ward, "WardID", "WardID", directory.WardID);
            return View(directory);
        }

        // GET: Directories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directory = await _context.Directory
                .Include(d => d.Ward)
                .FirstOrDefaultAsync(m => m.DirectoryID == id);
            if (directory == null)
            {
                return NotFound();
            }

            return View(directory);
        }

        // POST: Directories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directory = await _context.Directory.FindAsync(id);
            _context.Directory.Remove(directory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryExists(int id)
        {
            return _context.Directory.Any(e => e.DirectoryID == id);
        }
    }
}
