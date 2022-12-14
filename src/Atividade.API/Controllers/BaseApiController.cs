using Atividade.API.Data;
using Atividade.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Atividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController<T> : ControllerBase where T : BaseModel
    {
        protected readonly DataContext _context;

        public BaseApiController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public virtual async Task<IActionResult> List()
        {
            var entities = await _context.Set<T>().ToListAsync();

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Detail(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Detail", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(long id, T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            if (!await EntityExists(id))
            {
                return NotFound();
            }

            entity.UpdateAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> EntityExists(long id)
        {
            return _context.Set<T>().AnyAsync(e => e.Id == id);
        }
    }
}