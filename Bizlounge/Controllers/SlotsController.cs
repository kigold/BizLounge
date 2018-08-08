using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bizlounge.Data;
using Bizlounge.Models;

namespace Bizlounge.Controllers
{
    public class SlotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Slots
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Slot.Include(s => s.Project).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync( ));
        }

        // GET: Slots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .Include(s => s.Project)
                .Include(s => s.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // GET: Slots/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ID", "ID");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Slots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProjectId,UserId,AmountReceived")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ID", "ID", slot.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", slot.UserId);
            return View(slot);
        }

        // GET: Slots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot.SingleOrDefaultAsync(m => m.ID == id);
            if (slot == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ID", "ID", slot.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", slot.UserId);
            return View(slot);
        }

        // POST: Slots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProjectId,UserId,AmountReceived")] Slot slot)
        {
            if (id != slot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotExists(slot.ID))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ID", "ID", slot.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", slot.UserId);
            return View(slot);
        }

        // GET: Slots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .Include(s => s.Project)
                .Include(s => s.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // POST: Slots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slot = await _context.Slot.SingleOrDefaultAsync(m => m.ID == id);
            _context.Slot.Remove(slot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotExists(int id)
        {
            return _context.Slot.Any(e => e.ID == id);
        }
    }
}
