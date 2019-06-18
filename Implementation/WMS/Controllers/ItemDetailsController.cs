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

        // GET: ItemDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemDetails.ToListAsync());
        }

        // GET: ItemDetails/Details/5
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

        // GET: ItemDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: ItemDetails/Delete/5
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

        // POST: ItemDetails/Delete/5
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
