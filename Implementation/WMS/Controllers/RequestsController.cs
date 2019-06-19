using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WMS.Models;

namespace WMS.Controllers
{
    [Authorize]
    public class RequestsController : Controller
    {
        private readonly WMSContext _context;

        public RequestsController(WMSContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if(!User.IsInRole("Manager") && !User.IsInRole("Employee"))
            {
                var import = await _context.ImportRequests.Where(r => r.Firm.UserName == User.Identity.Name).Include(r => r.StorageSpace).ToListAsync();
                var export = await _context.ExportRequests.Where(r => r.Firm.UserName == User.Identity.Name).Include(r => r.StorageSpace).ToListAsync();
                var requests = new List<Request>();
                requests.AddRange(import);
                requests.AddRange(export);
                return View(requests);
            }
            else
            {
                var import = await _context.ImportRequests.Include(r => r.StorageSpace).ToListAsync();
                var export = await _context.ExportRequests.Include(r => r.StorageSpace).ToListAsync();
                var requests = new List<Request>();
                requests.AddRange(import);
                requests.AddRange(export);
                return View(requests);
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        public IActionResult CreateImport()
        {
            var storageSpaces = _context.StorageSpaces.Where(sp => sp.Firm.UserName == User.Identity.Name && sp.Available);
            ViewBag.StorageSpace = new SelectList(storageSpaces, "Id", "Name");
            return View();
        }

        public IActionResult CreateExport()
        {
            var storageSpaces = _context.StorageSpaces.Where(sp => sp.Firm.UserName == User.Identity.Name && sp.Available);
            ViewBag.StorageSpace = new SelectList(storageSpaces, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateImport(ImportRequest importRequest)
        {
            if (ModelState.IsValid)
            {
                var firm = _context.Firms.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                importRequest.Firm = firm;
                importRequest.RequestDate = DateTime.Now;
                _context.Add(importRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(importRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExport(ExportRequest exportRequest)
        {
            if (ModelState.IsValid)
            {
                var firm = _context.Firms.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                exportRequest.Firm = firm;
                exportRequest.RequestDate = DateTime.Now;
                _context.Add(exportRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exportRequest);
        }

        public async Task<IActionResult> Approve(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ImportRequest import = await _context.ImportRequests.FirstOrDefaultAsync(m => m.Id == id);
            ExportRequest export = await _context.ExportRequests.FirstOrDefaultAsync(m => m.Id == id);

            if(import != null)
            {
                return View(import);
            }
            else if(export != null)
            {
                return View(export);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(string id, ImportRequest request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    request.Processed = true;
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
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

            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(string id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
