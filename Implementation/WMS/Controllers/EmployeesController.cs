using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WMS.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMS.Controllers
{
    [Authorize(Roles = "Manager")]
    public class EmployeesController : Controller
    {
        private readonly WMSContext _context;

        public EmployeesController(WMSContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var res = _context.Employees.ToList();
            return View(res);
        }

        public async Task<IActionResult> Fire(string id)
        {
            var employee = _context.Employees.FirstOrDefault(m => m.Id == id);
            if( employee == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                }catch(Exception e)
                {
                    RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
