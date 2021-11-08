using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedbackSystemAPI.Models;

namespace FeedbackSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignTasksController : ControllerBase
    {
        private readonly FeedbacSystemkDBContext _context;

        public AssignTasksController(FeedbacSystemkDBContext context)
        {
            _context = context;
        }

        // GET: api/AssignTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignTask>>> GetAssignTasks()
        {
            return await _context.AssignTasks.ToListAsync();
        }

        // GET: api/AssignTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignTask>> GetAssignTask(string id)
        {
            var assignTask = await _context.AssignTasks.FindAsync(id);

            if (assignTask == null)
            {
                return NotFound();
            }

            return assignTask;
        }

        // PUT: api/AssignTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignTask(string id, AssignTask assignTask)
        {
            if (id != assignTask.AssignId)
            {
                return BadRequest();
            }

            _context.Entry(assignTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignTaskExists(id))
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

        // POST: api/AssignTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssignTask>> PostAssignTask(AssignTask assignTask)
        {
            _context.AssignTasks.Add(assignTask);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssignTaskExists(assignTask.AssignId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssignTask", new { id = assignTask.AssignId }, assignTask);
        }

        // DELETE: api/AssignTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignTask(string id)
        {
            var assignTask = await _context.AssignTasks.FindAsync(id);
            if (assignTask == null)
            {
                return NotFound();
            }

            _context.AssignTasks.Remove(assignTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignTaskExists(string id)
        {
            return _context.AssignTasks.Any(e => e.AssignId == id);
        }
    }
}
