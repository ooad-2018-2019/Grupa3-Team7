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
    public class ItemCountsController : ControllerBase
    {
        private readonly ProjectDatabaseContext _context;

        public ItemCountsController(ProjectDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ItemCounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCounts>>> GetItemCounts()
        {
            return await _context.ItemCounts.ToListAsync();
        }

        // GET: api/ItemCounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCounts>> GetItemCounts(int id)
        {
            var itemCounts = await _context.ItemCounts.FindAsync(id);

            if (itemCounts == null)
            {
                return NotFound();
            }

            return itemCounts;
        }

        // PUT: api/ItemCounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCounts(int id, ItemCounts itemCounts)
        {
            if (id != itemCounts.Count)
            {
                return BadRequest();
            }

            _context.Entry(itemCounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCountsExists(id))
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

        // POST: api/ItemCounts
        [HttpPost]
        public async Task<ActionResult<ItemCounts>> PostItemCounts(ItemCounts itemCounts)
        {
            _context.ItemCounts.Add(itemCounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemCounts", new { id = itemCounts.Count }, itemCounts);
        }

        // DELETE: api/ItemCounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemCounts>> DeleteItemCounts(int id)
        {
            var itemCounts = await _context.ItemCounts.FindAsync(id);
            if (itemCounts == null)
            {
                return NotFound();
            }

            _context.ItemCounts.Remove(itemCounts);
            await _context.SaveChangesAsync();

            return itemCounts;
        }

        private bool ItemCountsExists(int id)
        {
            return _context.ItemCounts.Any(e => e.Count == id);
        }
    }
}
