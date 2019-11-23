﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTips.Web.Data;
using MyTips.Web.Data.Entities;

namespace MyTips.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipsController : ControllerBase
    {
        private readonly DataContext _context;

        public TipsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Tips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tip>>> GetTips()
        {
            return await _context.Tips.OrderByDescending(l => l.StartDate).ToListAsync();
        }

        // GET: api/Tips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tip>> GetTip(int id)
        {
            var tip = await _context.Tips.FindAsync(id);

            if (tip == null)
            {
                return NotFound();
            }

            return tip;
        }

        // PUT: api/Tips/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTip(int id, Tip tip)
        {
            if (id != tip.Id)
            {
                return BadRequest();
            }

            _context.Entry(tip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipExists(id))
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

        // POST: api/Tips
        [HttpPost]
        public async Task<ActionResult<Tip>> PostTip(Tip tip)
        {
            _context.Tips.Add(tip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTip", new { id = tip.Id }, tip);
        }

        // DELETE: api/Tips/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tip>> DeleteTip(int id)
        {
            var tip = await _context.Tips.FindAsync(id);
            if (tip == null)
            {
                return NotFound();
            }

            _context.Tips.Remove(tip);
            await _context.SaveChangesAsync();

            return tip;
        }

        private bool TipExists(int id)
        {
            return _context.Tips.Any(e => e.Id == id);
        }
    }
}
