using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMS.Controllers
{
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
                warehouse.UsedUp = 0;
                var storages = await _context.StorageSpaces.ToListAsync();
                foreach (var storage in storages)
                {
                    warehouse.UsedUp += storage.Capacity;
                }
                warehouse.UsedUp /= warehouse.Capacity;
                warehouse.UsedUp *= 100;
                return View(warehouse);
            }
            return View();
        }




    }
}
