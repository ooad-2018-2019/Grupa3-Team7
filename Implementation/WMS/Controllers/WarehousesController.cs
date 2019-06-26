using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMS.Controllers
{
    [Authorize(Roles ="Manager")]
    public class WarehousesController : Controller
    {

        private readonly WMSContext _context;

        public WarehousesController(WMSContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Info()
        {
            var res = await _context.Warehouses.ToListAsync();

            if (res != null && res.Count == 0)
            {
                Warehouse warehouse = new Warehouse();
                warehouse.Name = "";
                warehouse.Adress = "";
                warehouse.Capacity = 100;
                warehouse.UsedUp = 0;
                _context.Warehouses.Add(warehouse);
                await _context.SaveChangesAsync();
                return View(warehouse);
            }
            else if(res != null && res.Count >0)
            {
                Warehouse warehouse = res.First();
                warehouse.UsedUp = 0;
                var storageCapacities = await _context.StorageSpaces.Select(m => m.Capacity).ToListAsync();
                foreach (var storageCapacity in storageCapacities)
                {
                    warehouse.UsedUp += storageCapacity;
                }
                warehouse.UsedUp /= warehouse.Capacity;
                warehouse.UsedUp *= 100;
                return View(warehouse);
            }
            return Redirect("/../Home");
        }


        public async Task<IActionResult> Edit()
        {
            var res = await _context.Warehouses.ToListAsync();

            if (res == null || res.Count == 0)
            {
                Warehouse warehouse = new Warehouse();
                warehouse.Name = "";
                warehouse.Adress = "";
                warehouse.Capacity = 100;
                warehouse.UsedUp = 0;
            }
            else
            {
                Warehouse warehouse = res.First();
                return View(warehouse);
            }
            return Redirect("/../Home");
        }


        public async Task<IActionResult> EditConfirmed(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
            await _context.SaveChangesAsync();
            return Redirect("/../Home");
        }







    }
}
