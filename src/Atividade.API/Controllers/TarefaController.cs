using Atividade.API.Data;
using Atividade.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Atividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : BaseApiController<TarefaModel>
    {
        public TarefaController(DataContext context) : base(context)
        {
        }
        [HttpGet]
        public override async Task<IActionResult> List()
        {
            var entities = await _context.Tarefas.Where(p => !p.Excluido).ToListAsync();

            return Ok(entities);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Tarefas.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Excluido = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}