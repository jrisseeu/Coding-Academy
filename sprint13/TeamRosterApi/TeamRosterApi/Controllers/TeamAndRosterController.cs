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
    [Route("api/[controller]")]
    [ApiController]
    public class TeamAndRosterController : ControllerBase
    {
        private readonly TeamRosterContext _context;

        public TeamAndRosterController(TeamRosterContext context)
        {
            _context = context;
        }

        // GET: api/TeamAndRoster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamAndRosterModel>>> GetTeamInfo()
        {
            return await _context.TeamInfo.ToListAsync();
        }

        // GET: api/TeamAndRoster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamAndRosterModel>> GetTeamAndRosterModel(int id)
        {
            var teamAndRosterModel = await _context.TeamInfo.FindAsync(id);

            if (teamAndRosterModel == null)
            {
                return NotFound();
            }

            return teamAndRosterModel;
        }

        // PUT: api/TeamAndRoster/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamAndRosterModel(int id, TeamAndRosterModel teamAndRosterModel)
        {
            if (id != teamAndRosterModel.teamId)
            {
                return BadRequest();
            }

            _context.Entry(teamAndRosterModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamAndRosterModelExists(id))
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

        // POST: api/TeamAndRoster
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamAndRosterModel>> PostTeamAndRosterModel(TeamAndRosterModel teamAndRosterModel)
        {
            _context.TeamInfo.Add(teamAndRosterModel);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTeamAndRosterModel", new { id = teamAndRosterModel.teamId }, teamAndRosterModel);
            return CreatedAtAction(nameof(GetTeamAndRosterModel), new { id = teamAndRosterModel.teamId  }, teamAndRosterModel);
        }

        // DELETE: api/TeamAndRoster/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamAndRosterModel(int id)
        {
            var teamAndRosterModel = await _context.TeamInfo.FindAsync(id);
            if (teamAndRosterModel == null)
            {
                return NotFound();
            }

            _context.TeamInfo.Remove(teamAndRosterModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamAndRosterModelExists(int id)
        {
            return _context.TeamInfo.Any(e => e.teamId == id);
        }
    }
}
