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
    [Route("api/player")]
    [ApiController]
    public class PlayerModelController : ControllerBase
    {
        private readonly TeamRosterContext _context;

        public PlayerModelController(TeamRosterContext context)
        {
            _context = context;
        }

        // GET: api/PlayerModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerModel>>> GetPlayerModel()
        {
            return await _context.PlayerModel.ToListAsync();
        }

        // GET: api/PlayerModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerModel>> GetPlayerModel(int id)
        {
            var playerModel = await _context.PlayerModel.FindAsync(id);

            if (playerModel == null)
            {
                return NotFound();
            }

            return playerModel;
        }

        // PUT: api/PlayerModel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerModel(int id, PlayerModel playerModel)
        {
            if (id != playerModel.playerId)
            {
                return BadRequest();
            }

            _context.Entry(playerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerModelExists(id))
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

        // POST: api/PlayerModel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerModel>> PostPlayerModel(PlayerModel playerModel)
        {
            _context.PlayerModel.Add(playerModel);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPlayerModel", new { id = playerModel.playerId }, playerModel);
            return CreatedAtAction(nameof(GetPlayerModel), new { id = playerModel.playerId }, playerModel);
        }

        // DELETE: api/PlayerModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerModel(int id)
        {
            var playerModel = await _context.PlayerModel.FindAsync(id);
            if (playerModel == null)
            {
                return NotFound();
            }

            _context.PlayerModel.Remove(playerModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerModelExists(int id)
        {
            return _context.PlayerModel.Any(e => e.playerId == id);
        }
    }
}
