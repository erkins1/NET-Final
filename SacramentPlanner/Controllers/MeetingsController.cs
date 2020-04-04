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
    public class MeetingsController : Controller
    {
        private readonly SacramentPlannerContext _context;

        public MeetingsController(SacramentPlannerContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            var sacramentPlannerContext = _context.Meeting
                .Include(m => m.BenedictionDirectory)
                .Include(m => m.Closing_HymnHymn)
                .Include(m => m.ConductingDirectory)
                .Include(m => m.InvocationDirectory)
                .Include(m => m.Opening_HymnHymn)
                .Include(m => m.PresidingDirectory)
                .Include(m => m.Sacrament_HymnHymn)
                .Include(m => m.Ward);
            return View(await sacramentPlannerContext.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.BenedictionDirectory)
                .Include(m => m.Closing_HymnHymn)
                .Include(m => m.ConductingDirectory)
                .Include(m => m.InvocationDirectory)
                .Include(m => m.Opening_HymnHymn)
                .Include(m => m.PresidingDirectory)
                .Include(m => m.Sacrament_HymnHymn)
                .Include(m => m.Ward)
                .FirstOrDefaultAsync(m => m.MeetingID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            ViewData["Benediction"] = new SelectList(_context.Directory, "DirectoryID", "Full_Name");
            ViewData["Closing_Hymn"] = new SelectList(_context.Hymn, "HymnID", "Hymn_Name");
            ViewData["Conducting"] = new SelectList(_context.Directory, "DirectoryID", "First_Name");
            ViewData["Invocation"] = new SelectList(_context.Directory, "DirectoryID", "First_Name");
            ViewData["Opening_Hymn"] = new SelectList(_context.Hymn, "HymnID", "Hymn_Name");
            ViewData["Presiding"] = new SelectList(_context.Directory, "DirectoryID", "First_Name");
            ViewData["Sacrament_Hymn"] = new SelectList(_context.Hymn, "HymnID", "Hymn_Name");
            ViewData["WardID"] = new SelectList(_context.Ward, "WardID", "Ward_Name");

            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingID,Date,WardID,Presiding,Conducting,Opening_Hymn,Invocation,Ward_Business,Sacrament,Sacrament_Hymn,Closing_Hymn,Benediction")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Benediction"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Benediction);
            ViewData["Closing_Hymn"] = new SelectList(_context.Hymn, "HymnID", "HymnID", meeting.Closing_Hymn);
            ViewData["Conducting"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Conducting);
            ViewData["Invocation"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Invocation);
            ViewData["Opening_Hymn"] = new SelectList(_context.Hymn, "HymnID", "HymnID", meeting.Opening_Hymn);
            ViewData["Presiding"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Presiding);
            ViewData["Sacrament_Hymn"] = new SelectList(_context.Hymn, "HymnID", "HymnID", meeting.Sacrament_Hymn);
            ViewData["WardID"] = new SelectList(_context.Ward, "WardID", "Ward_Name", meeting.WardID);
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            ViewData["Benediction"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Benediction);
            ViewData["Closing_Hymn"] = new SelectList(_context.Hymn, "HymnID", "HymnID", meeting.Closing_Hymn);
            ViewData["Conducting"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Conducting);
            ViewData["Invocation"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Invocation);
            ViewData["Opening_Hymn"] = new SelectList(_context.Hymn, "HymnID", "HymnID", meeting.Opening_Hymn);
            ViewData["Presiding"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Presiding);
            ViewData["Sacrament_Hymn"] = new SelectList(_context.Hymn, "HymnID", "HymnID", meeting.Sacrament_Hymn);
            ViewData["WardID"] = new SelectList(_context.Ward, "WardID", "Ward_Name", meeting.WardID);
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeetingID,Date,WardID,Presiding,Conducting,Opening_Hymn,Invocation,Ward_Business,Sacrament,Sacrament_Hymn,Closing_Hymn,Benediction")] Meeting meeting)
        {
            if (id != meeting.MeetingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.MeetingID))
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
            ViewData["Benediction"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Benediction);
            ViewData["Closing_Hymn"] = new SelectList(_context.Hymn, "HymnID", "HymnID", meeting.Closing_Hymn);
            ViewData["Conducting"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Conducting);
            ViewData["Invocation"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Invocation);
            ViewData["Opening_Hymn"] = new SelectList(_context.Hymn, "HymnID", "HymnID", meeting.Opening_Hymn);
            ViewData["Presiding"] = new SelectList(_context.Directory, "DirectoryID", "First_Name", meeting.Presiding);
            ViewData["Sacrament_Hymn"] = new SelectList(_context.Hymn, "HymnID", "HymnID", meeting.Sacrament_Hymn);
            ViewData["WardID"] = new SelectList(_context.Ward, "WardID", "Ward_Name", meeting.WardID);
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.BenedictionDirectory)
                .Include(m => m.Closing_HymnHymn)
                .Include(m => m.ConductingDirectory)
                .Include(m => m.InvocationDirectory)
                .Include(m => m.Opening_HymnHymn)
                .Include(m => m.PresidingDirectory)
                .Include(m => m.Sacrament_HymnHymn)
                .Include(m => m.Ward)
                .FirstOrDefaultAsync(m => m.MeetingID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.FindAsync(id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.MeetingID == id);
        }
    }
}
