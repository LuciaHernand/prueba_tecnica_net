using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MBAOptionsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public MBAOptionsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/MBAOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MBAOption>>> GetMBAOptions()
        {
            return await _context.MBAOptions.ToListAsync();
        }

        // GET: api/MBAOptions/
        [HttpGet("{id}")]
        public async Task<ActionResult<MBAOption>> GetMBAOptions(int id)
        {
            var option = await _context.MBAOptions.FindAsync(id);

            if (option == null)
            {
                return NotFound();
            }

            return option;
        }

        // POST: api/MBAOptions
        [HttpPost]
        public async Task<ActionResult<MBAOption>> CreateOption([FromBody] MBAOption option)
        {
            if (option == null)
            {
                return BadRequest("La opción no puede ser nula.");
            }

              _context.MBAOptions.Add(option);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMBAOptions), new { id = option.OptionId }, option);
        }

        // PUT: api/MBAOptions/
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOption(int id, [FromBody] MBAOption option)
        {
            if (id != option.OptionId)
            {
                return BadRequest();
            }

            _context.Entry(option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MBAOptionsExists(id))
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
        private bool MBAOptionsExists(int id) 
        {
            return _context.MBAOptions.Any(e => e.OptionId == id);
        }
    }


}



