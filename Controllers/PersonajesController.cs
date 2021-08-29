using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDisney.Models;

namespace APIDisney.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PersonajesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Personajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personaje>>> GetPersonaje()
        {
            return await _context.Personaje.ToListAsync();
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Personaje>>> SearchPersonajeByNameTask(string name)
        {
            IQueryable<Personaje> query = _context.Personaje;
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(n => n.Nombre.Contains(name));
                    return Ok(query);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return await query.ToListAsync();
        }
        /*[HttpGet("{Nombre:string}")]
         public IEnumerable<Personaje> SearchPersonajeByName(string nombre)
         {
             if(!string.IsNullOrEmpty(nombre))
             {
                 return _context.Personaje.Where(n => n.Nombre.Contains(nombre));
             }
             else
             {
                 return _context.Personaje;
             }
         }*/
        // GET: api/Personajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> GetPersonaje(int id)
        {
            var personaje = await _context.Personaje.FindAsync(id);

            if (personaje == null)
            {
                return NotFound();
            }

            return personaje;
        }

        // PUT: api/Personajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaje(int id, Personaje personaje)
        {
            if (id != personaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(personaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonajeExists(id))
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

        // POST: api/Personajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personaje>> PostPersonaje(Personaje personaje)
        {
            _context.Personaje.Add(personaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonaje", new { id = personaje.Id }, personaje);
        }

        // DELETE: api/Personajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaje(int id)
        {
            var personaje = await _context.Personaje.FindAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }

            _context.Personaje.Remove(personaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonajeExists(int id)
        {
            return _context.Personaje.Any(e => e.Id == id);
        }
    }
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
