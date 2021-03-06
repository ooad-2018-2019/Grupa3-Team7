﻿using System;
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
    public class RequestsController : ControllerBase
    {
        private readonly ProjectDatabaseContext _context;

        public RequestsController(ProjectDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requests>>> GetRequests()
        {
            var requests = await _context.Requests.ToListAsync();
            foreach(Requests request in requests)
            {
                var itemCounts = _context.ItemCounts.Where(ic => ic.RequestId == request.Id).Include(ic => ic.ItemUpcNavigation).ToListAsync();
                request.ItemCounts = await itemCounts;
            }

            return requests;
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requests>> GetRequests(string id)
        {
            var requests = await _context.Requests.FindAsync(id);

            if (requests == null)
            {
                return NotFound();
            }

            return requests;
        }

        // PUT: api/Requests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequests(string id, Requests requests)
        {
            if (id != requests.Id)
            {
                return BadRequest();
            }

            _context.Entry(requests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestsExists(id))
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

        // POST: api/Requests
        [HttpPost]
        public async Task<ActionResult<Requests>> PostRequests([FromBody] Requests requests)
        {
            requests.RequestDate = DateTime.Now;
            var count = await _context.Requests.LongCountAsync();
            requests.Id = "rq" + count;

            for(int i = 0; i < requests.ItemCounts.Count; i++)
            {
                ItemCounts itemCounts = requests.ItemCounts.ElementAt(i);
                itemCounts.RequestId = requests.Id;
                itemCounts.Id = requests.Id + "-" + i;
            }

            _context.Requests.Add(requests);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RequestsExists(requests.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRequests", new { id = requests.Id }, requests);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Requests>> DeleteRequests(string id)
        {
            var requests = await _context.Requests.FindAsync(id);
            if (requests == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(requests);
            await _context.SaveChangesAsync();

            return requests;
        }

        private bool RequestsExists(string id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
