using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecetasApp.Common.Models;
using RecetasApp.Web.Data;
using RecetasApp.Web.Data.Entities;

namespace RecetasApp.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Recetas1Controller : ControllerBase
    {
        private readonly DataContext _dataContext;

        public Recetas1Controller(DataContext context)
        {
            _dataContext = context;
        }


        [HttpPost]
        [Route("GetRecetaByEmail")]
        public async Task<IActionResult> GetRecetaByEmailAsync(EmailRequest emailRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var receta = await _dataContext.Recetas.FirstOrDefaultAsync(r => r.User.Email.ToLower() == emailRequest.Email.ToLower());
            
            //.Include(r=>r.User)        
            //.Include(r => r.PasosRecetas)

            /*
                        var response = new RecetasResponce
                        {
                            Id = receta.Id,
                            Nombre = receta.Nombre,
                            Descripcion = receta.Descripcion,
                            Tiempo = receta.Tiempo,
                            Raciones = receta.Raciones,
                            ImagenUrl = receta.ImageFullPath,

                            Temporada = receta.Temporada,
                            Dificultad = receta.Dificultad,
                            User = receta.User,
                            ActiComentarios = receta.ActiComentarios,
                            NumLikes = receta.NumLikes,
                            PasosRecetas = receta.PasosRecetas.Select(p => new PasosRecetaResponce
                            {
                                Id=p.Id,
                                RecetaId=receta.Id,
                                NumPaso=p.NumPaso,
                                Instrucciones=p.Instrucciones,

                            }).ToList()
                        };
                        */
            if (receta == null)
            {
                return NotFound();
            }
            return Ok(receta);
        }



        /*
        // GET: api/Recetas1
        [HttpGet]
        public IEnumerable<Receta> GetRecetas()
        {
            return _context.Recetas;
        }

        // GET: api/Recetas1/5
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

        // PUT: api/Recetas1/5
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

        // POST: api/Recetas1
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

        // DELETE: api/Recetas1/5
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
        */
    }
}