using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LotteryAPI.Models;

namespace LotteryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawHistoryController : ControllerBase
    {
        private readonly DrawHistoryContext _context;

        public DrawHistoryController(DrawHistoryContext context)
        {
            _context = context;
        }

        // GET: api/DrawHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrawHistory>>> GetDrawHistories()
        {
            //int kek = _context.DrawHistories.LastAsync().Result.DrawId+1;
            int drawid = _context.DrawHistories.Max(x => x.DrawId);
            drawid++;
            //int kek = 2;
            string date = DateTime.Now.ToString();

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                int drawnumber = random.Next(1, 51);

                DrawHistory drawHistory = new DrawHistory();
                drawHistory.Date = date;
                drawHistory.DrawId = drawid;
                drawHistory.Draw = drawnumber;

                _context.DrawHistories.Add(drawHistory);
                await _context.SaveChangesAsync();
            }

            return await _context.DrawHistories.ToListAsync();
        }

        // GET: api/DrawHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrawHistory>> GetDrawHistory(int id)
        {
            var drawHistory = await _context.DrawHistories.FindAsync(id);

            if (drawHistory == null)
            {
                return NotFound();
            }

            return drawHistory;
        }

        // PUT: api/DrawHistory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrawHistory(int id, DrawHistory drawHistory)
        {
            if (id != drawHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(drawHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrawHistoryExists(id))
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

        // POST: api/DrawHistory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DrawHistory>> PostDrawHistory(DrawHistory drawHistory)
        {
            _context.DrawHistories.Add(drawHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrawHistory", new { id = drawHistory.Id }, drawHistory);
        }

        // DELETE: api/DrawHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrawHistory(int id)
        {
            var drawHistory = await _context.DrawHistories.FindAsync(id);
            if (drawHistory == null)
            {
                return NotFound();
            }

            _context.DrawHistories.Remove(drawHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrawHistoryExists(int id)
        {
            return _context.DrawHistories.Any(e => e.Id == id);
        }
    }
}
