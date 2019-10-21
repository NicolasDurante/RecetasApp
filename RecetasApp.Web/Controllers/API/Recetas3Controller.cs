using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecetasApp.Web.Data;
using RecetasApp.Web.Data.Entities;

namespace RecetasApp.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Recetas3Controller : Controller
    {


        private readonly DataContext _context;

        public Recetas3Controller(DataContext context)
        {
            _context = context;
        }

        // GET: api/Recetas3
        [HttpGet]
        public IEnumerable<Receta> GetRecetas()
        {
            return _context.Recetas;
        }

        // GET: api/Recetas3/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receta = await _context.Recetas.FindAsync(id);

            if (receta == null)
            {
                return NotFound();
            }

            return Ok(receta);
        }

        // PUT: api/Recetas3/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceta([FromRoute] int id, [FromBody] Receta receta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receta.Id)
            {
                return BadRequest();
            }

            _context.Entry(receta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetaExists(id))
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

        // POST: api/Recetas3
        [HttpPost]
        public async Task<IActionResult> PostReceta([FromBody] Receta receta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Recetas.Add(receta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceta", new { id = receta.Id }, receta);
        }

        // DELETE: api/Recetas3/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receta = await _context.Recetas.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }

            _context.Recetas.Remove(receta);
            await _context.SaveChangesAsync();

            return Ok(receta);
        }

        private bool RecetaExists(int id)
        {
            return _context.Recetas.Any(e => e.Id == id);
        }
    }
}