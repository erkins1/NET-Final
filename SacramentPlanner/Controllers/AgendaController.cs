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
    public class AgendaController : Controller
    {
        private readonly SacramentPlannerContext _context;

        public static int? AgendaMeetingID { get; set; }

        public AgendaController(SacramentPlannerContext context)
        {
            _context = context;
        }

        // GET: Agenda
        // This was removed in favor of the index below
        /*public async Task<IActionResult> Index()
        {
            var sacramentPlannerContext = _context.Agenda.Include(a => a.Directory).Include(a => a.Hymn).Include(a => a.Meeting);
            return View(await sacramentPlannerContext.ToListAsync());
        }
        */

        // GET: Agenda/5
        // Returns the index filtered for a specific meeting
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null) { 
                AgendaMeetingID = id;
            }
            
            var sacramentPlannerContext = _context.Agenda.Include(a => a.Directory).Include(a => a.Hymn).Include(a => a.Meeting).Where(a => a.MeetingID == AgendaMeetingID);
            return View(await sacramentPlannerContext.ToListAsync());
        }

        //GET: Meeting/5
        //Forward the user to the Meetings controller
        public IActionResult Meeting()
        {
            return RedirectToAction("Index", "Meetings");
        }

        // GET: Agenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .Include(a => a.Directory)
                .Include(a => a.Hymn)
                .Include(a => a.Meeting)
                .FirstOrDefaultAsync(m => m.AgendaID == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // GET: Agenda/Create
        public IActionResult Create()
        {
            ViewData["MemberID"] = new SelectList(_context.Directory, "DirectoryID", "First_Name");
            ViewData["HymnID"] = new SelectList(_context.Hymn, "HymnID", "HymnID");
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "MeetingID", "MeetingID", AgendaMeetingID);

            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendaID,MeetingID,Section,MemberID,HymnID,Special_Event_Text,Notes,Subject")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberID"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", agenda.MemberID);
            ViewData["HymnID"] = new SelectList(_context.Hymn, "HymnID", "HymnID", agenda.HymnID);
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "MeetingID", "MeetingID", agenda.MeetingID);
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }
            ViewData["MemberID"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", agenda.MemberID);
            ViewData["HymnID"] = new SelectList(_context.Hymn, "HymnID", "HymnID", agenda.HymnID);
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "MeetingID", "MeetingID", agenda.MeetingID);
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgendaID,MeetingID,Section,MemberID,HymnID,Special_Event_Text,Notes,Subject")] Agenda agenda)
        {
            if (id != agenda.AgendaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.AgendaID))
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
            ViewData["MemberID"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", agenda.MemberID);
            ViewData["HymnID"] = new SelectList(_context.Hymn, "HymnID", "HymnID", agenda.HymnID);
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "MeetingID", "MeetingID", agenda.MeetingID);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .Include(a => a.Directory)
                .Include(a => a.Hymn)
                .Include(a => a.Meeting)
                .FirstOrDefaultAsync(m => m.AgendaID == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda = await _context.Agenda.FindAsync(id);
            _context.Agenda.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaExists(int id)
        {
            return _context.Agenda.Any(e => e.AgendaID == id);
        }
    }
}
