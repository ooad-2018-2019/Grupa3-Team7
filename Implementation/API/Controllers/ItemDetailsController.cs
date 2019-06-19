using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDetailsController : ControllerBase
    {
        private readonly ProjectDatabaseContext _context;

        public ItemDetailsController(ProjectDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ItemDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDetails>>> GetItemDetails()
        {
            return await _context.ItemDetails.ToListAsync();
        }

        // GET: api/ItemDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDetails>> GetItemDetails(string id)
        {
            var itemDetails = await _context.ItemDetails.FindAsync(id);

            if (itemDetails == null)
            {
                return NotFound();
            }

            return itemDetails;
        }

        // PUT: api/ItemDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemDetails(string id, ItemDetails itemDetails)
        {
            if (id != itemDetails.Upc)
            {
                return BadRequest();
            }

            _context.Entry(itemDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/ItemDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDetails>> DeleteItemDetails(string id)
        {
            var itemDetails = await _context.ItemDetails.FindAsync(id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            _context.ItemDetails.Remove(itemDetails);
            await _context.SaveChangesAsync();

            return itemDetails;
        }

        private bool ItemDetailsExists(string id)
        {
            return _context.ItemDetails.Any(e => e.Upc == id);
        }
    }
}
