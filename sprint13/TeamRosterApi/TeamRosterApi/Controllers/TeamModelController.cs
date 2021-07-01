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
    [Route("api/team")]
    [ApiController]
    public class TeamModelController : ControllerBase
    {
        private readonly TeamRosterContext _context;

        public TeamModelController(TeamRosterContext context)
        {
            _context = context;
        }

        // GET: api/TeamModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamModel>>> GetTeamModel()
        {
            return await _context.TeamModel.ToListAsync();
        }

        // GET: api/TeamModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamModel>> GetTeamModel(int id)
        {
            var teamModel = await _context.TeamModel.FindAsync(id);

            if (teamModel == null)
            {
                return NotFound();
            }

            return teamModel;
        }

        // PUT: api/TeamModel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamModel(int id, TeamModel teamModel)
        {
            if (id != teamModel.teamId)
            {
                return BadRequest();
            }

            _context.Entry(teamModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamModelExists(id))
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

        // POST: api/TeamModel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamModel>> PostTeamModel(TeamModel teamModel)
        {
            _context.TeamModel.Add(teamModel); await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTeamModel", new { id = teamModel.teamId }, teamModel);
            return CreatedAtAction(nameof(GetTeamModel), new { id = teamModel.teamId }, teamModel);
        }

        // DELETE: api/TeamModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamModel(int id)
        {
            var teamModel = await _context.TeamModel.FindAsync(id);
            if (teamModel == null)
            {
                return NotFound();
            }

            _context.TeamModel.Remove(teamModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamModelExists(int id)
        {
            return _context.TeamModel.Any(e => e.teamId == id);
        }
    }
}
