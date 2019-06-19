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
    public class ItemDetailsController : Controller
    {
        private readonly WMSContext _context;

        public ItemDetailsController(WMSContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemDetails.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDetails = await _context.ItemDetails
                .FirstOrDefaultAsync(m => m.UPC == id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            return View(itemDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UPC,Name,Volume,Description,ImageURI")] ItemDetails itemDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemDetails);
        }

        [Authorize(Roles ="Manager")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDetails = await _context.ItemDetails
                .FirstOrDefaultAsync(m => m.UPC == id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            return View(itemDetails);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var itemDetails = await _context.ItemDetails.FindAsync(id);
            _context.ItemDetails.Remove(itemDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemDetailsExists(string id)
        {
            return _context.ItemDetails.Any(e => e.UPC == id);
        }
    }
}
