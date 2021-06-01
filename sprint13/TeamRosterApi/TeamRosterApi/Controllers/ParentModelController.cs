using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamRosterApi;
using TeamRosterApi.Models;

namespace TeamRosterApi.Controllers
{
    [Route("api/Parent")]
    [ApiController]
    public class ParentModelController : ControllerBase
    {
        private readonly TeamRosterContext _context;

        public ParentModelController(TeamRosterContext context)
        {
            _context = context;
        }

        // GET: api/ParentModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentModel>>> GetParentModel()
        {
            return await _context.ParentModel.ToListAsync();
        }

        // GET: api/ParentModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParentModel>> GetParentModel(int id)
        {
            var parentModel = await _context.ParentModel.FindAsync(id);

            if (parentModel == null)
            {
                return NotFound();
            }

            return parentModel;
        }

        // PUT: api/ParentModel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParentModel(int id, ParentModel parentModel)
        {
            if (id != parentModel.parentId)
            {
                return BadRequest();
            }

            _context.Entry(parentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentModelExists(id))
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

        // POST: api/ParentModel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParentModel>> PostParentModel(ParentModel parentModel)
        {
            _context.ParentModel.Add(parentModel);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetParentModel", new { id = parentModel.parentId }, parentModel);
            return CreatedAtAction(nameof(GetParentModel), new { id = parentModel.parentId  }, parentModel);
        }

        // DELETE: api/ParentModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParentModel(int id)
        {
            var parentModel = await _context.ParentModel.FindAsync(id);
            if (parentModel == null)
            {
                return NotFound();
            }

            _context.ParentModel.Remove(parentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParentModelExists(int id)
        {
            return _context.ParentModel.Any(e => e.parentId == id);
        }
    }
}
