using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.Controllers
{
    public class ExportRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExportRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExportRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExportRequests.ToListAsync());
        }

        // GET: ExportRequests/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportRequest = await _context.ExportRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exportRequest == null)
            {
                return NotFound();
            }

            return View(exportRequest);
        }

        // GET: ExportRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExportRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequestDate,Processed")] ExportRequest exportRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exportRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exportRequest);
        }

        // GET: ExportRequests/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportRequest = await _context.ExportRequests.FindAsync(id);
            if (exportRequest == null)
            {
                return NotFound();
            }
            return View(exportRequest);
        }

        // POST: ExportRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,RequestDate,Processed")] ExportRequest exportRequest)
        {
            if (id != exportRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exportRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExportRequestExists(exportRequest.Id))
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
            return View(exportRequest);
        }

        // GET: ExportRequests/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportRequest = await _context.ExportRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exportRequest == null)
            {
                return NotFound();
            }

            return View(exportRequest);
        }

        // POST: ExportRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var exportRequest = await _context.ExportRequests.FindAsync(id);
            _context.ExportRequests.Remove(exportRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExportRequestExists(string id)
        {
            return _context.ExportRequests.Any(e => e.Id == id);
        }
    }
}
