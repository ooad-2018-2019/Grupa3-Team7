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
    public class StorageSpacesController : Controller
    {
        private readonly WMSContext _context;

        public StorageSpacesController(WMSContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["user"] = User.Identity.Name;

            if (User.IsInRole("Firm"))
            {
                var res = await _context.StorageSpaces
                    .Where(sp => sp.Firm.UserName == User.Identity.Name)
                    .Include(sp => sp.Firm)
                    .Include(sp => sp.Items).ThenInclude(i => i.ItemDetails)
                    .ToListAsync();
                return View(res);
            }
            else
            {
                var x = await _context.StorageSpaces
                    .Include(sp => sp.Firm)
                    .Include(sp => sp.Items).ThenInclude(i => i.ItemDetails)
                    .ToListAsync();
                return View(x);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StorageSpace storageSpace)
        {
            if (ModelState.IsValid)
            {
                var firm = _context.Firms.Where(f => f.UserName == User.Identity.Name).FirstOrDefault();
                if(firm == null)
                {
                    return NotFound();
                }
                storageSpace.Firm = firm;
                _context.Add(storageSpace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storageSpace);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageSpace = await _context.StorageSpaces.Include(sp => sp.Firm).Include(sp => sp.Items).FirstOrDefaultAsync(m => m.Id == id);
            foreach ( Item item in storageSpace.Items)
            {
                var something = await _context.Items.Include(tempItem => tempItem.ItemDetails).FirstOrDefaultAsync(m => m.Id == item.Id);
                item.ItemDetails = something.ItemDetails;
            }
            if (storageSpace == null)
            {
                return NotFound();
            }

            return View(storageSpace);
        }

        public async Task<IActionResult> Approve(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageSpace storageSpace = await _context.StorageSpaces.FirstOrDefaultAsync(m => m.Id == id);

            if(storageSpace == null)
            {
                return NotFound();
            }

            return View(storageSpace);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(string id, StorageSpace storageSpace)
        {
            if (id != storageSpace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    storageSpace.Available = true;
                    _context.Entry(storageSpace).Property("Available").IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageSpaceExists(storageSpace.Id))
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

            return View(storageSpace);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageSpace = await _context.StorageSpaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storageSpace == null)
            {
                return NotFound();
            }

            return View(storageSpace);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var storageSpace = await _context.StorageSpaces.FindAsync(id);
            try
            {
                _context.StorageSpaces.Remove(storageSpace);
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private bool StorageSpaceExists(string id)
        {
            return _context.StorageSpaces.Any(e => e.Id == id);
        }
    }
}