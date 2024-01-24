using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaP3.Data;
using PruebaP3.Model;

namespace PruebaP3Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : Controller
    {
        private readonly TareaDbContext _context;

        public TareaController(TareaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Tarea nueva)
        {
            try
            {
                await _context.Tareas.AddAsync(nueva);
                await _context.SaveChangesAsync();

                return Ok(nueva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Tarea> tareas = new List<Tarea>();
            try
            {
                tareas = _context.Tareas.ToList();

                return Ok(tareas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Tarea tarea = await _context.Tareas.FirstOrDefaultAsync( x => x.Id == id);

                return Ok(tarea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscar/{nombre}/{estado}")]
        public async Task<IActionResult> Find(string nombre, string estado)
        {
            try
            {
                List<Tarea> tarea = _context.Tareas.ToList().FindAll(x => x.Nombre == nombre && x.Estado == estado);
                return Ok(tarea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
