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

        // GET: StorageSpaces
        public async Task<IActionResult> Index()
        {
            var user = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewData["user"] = user.UserName;

            if (!User.IsInRole("Manager") && !User.IsInRole("Employee"))
            {
                var res = await _context.StorageSpaces.Where(r => r.Firm.Id == user.Id).ToListAsync();
                return View(res);
            }
            else
            {
                var x = await _context.StorageSpaces.ToListAsync();
                return View(x);
            }
        }

        // GET: StorageSpaces/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageSpace = await _context.StorageSpaces
                .FirstOrDefaultAsync(m => m.Id == id);

            var user = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if(storageSpace.Firm.UserName != user.UserName)
            {
                return NotFound();
            }

            if (storageSpace == null)
            {
                return NotFound();
            }

            return View(storageSpace);
        }

        // GET: StorageSpaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StorageSpaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Capacity")] StorageSpace storageSpace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storageSpace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storageSpace);
        }

        // GET: StorageSpaces/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageSpace = await _context.StorageSpaces.FindAsync(id);
            if (storageSpace == null)
            {
                return NotFound();
            }
            return View(storageSpace);
        }

        // POST: StorageSpaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Capacity")] StorageSpace storageSpace)
        {
            if (id != storageSpace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storageSpace);
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

        // GET: StorageSpaces/Delete/5
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

        // POST: StorageSpaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var storageSpace = await _context.StorageSpaces.FindAsync(id);
            _context.StorageSpaces.Remove(storageSpace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageSpaceExists(string id)
        {
            return _context.StorageSpaces.Any(e => e.Id == id);
        }
    }
}