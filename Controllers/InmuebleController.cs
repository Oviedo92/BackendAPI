using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmuebleController : ControllerBase
    {
        private readonly ContextBD _context;
        private readonly IMapper _mapper;

        public InmuebleController(ContextBD context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Inmueble
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InmuebleDTO>>> GetInmuebles()
        {
            var inmueble = await _context.Inmuebles
                .ToListAsync();

            var resultado = _mapper.Map<List<InmuebleDTO>>(inmueble);

            return Ok(resultado);
        }

        // GET: api/Inmueble/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inmueble>> GetInmueble(int id)
        {
            var inmueble = await _context.Inmuebles
                .FirstOrDefaultAsync(p => p.Id_inmueble == id);

            if (inmueble == null)
                return NotFound();

            return inmueble;
        }

        // POST: api/Inmueble
        [HttpPost]
        public async Task<ActionResult<Inmueble>> PostInmueble(Inmueble inmueble)
        {
            // Validar que el Identif_cuenta venga del cliente
            if (string.IsNullOrWhiteSpace(inmueble.Identif_cuenta))
                return BadRequest("El Identif_cuenta del usuario es obligatorio.");

            // Validar patrón correcto (EmpresaXXXXXX o UserXXXXXX)
            var empresaRegex = new Regex(@"^Empresa\d{6}$");
            var usuarioRegex = new Regex(@"^user\d{6}$");

            if (!empresaRegex.IsMatch(inmueble.Identif_cuenta) && !usuarioRegex.IsMatch(inmueble.Identif_cuenta))
            {
                return BadRequest("El Identif_cuenta debe comenzar con 'Empresa' o 'User' seguido de 6 dígitos.");
            }

            if (usuarioRegex.IsMatch(inmueble.Identif_cuenta))
            {
                // Entra a un usuario
                var persona = await _context.Persona
                    .FirstOrDefaultAsync(p => p.Cod_ref_usuario == inmueble.Identif_cuenta);

                if (persona == null)
                    return BadRequest($"No existe un usuario con Identif_cuenta '{inmueble.Identif_cuenta}'.");
            }
            else if (empresaRegex.IsMatch(inmueble.Identif_cuenta))
            {
                // Entra a una empresa
                var empresa = await _context.Empresa
                    .FirstOrDefaultAsync(e => e.Cod_ref_empresa == inmueble.Identif_cuenta);

                if (empresa == null)
                    return BadRequest($"No existe una empresa con Identif_cuenta '{inmueble.Identif_cuenta}'.");
            }

            // Guardar el inmueble en la BD
            _context.Inmuebles.Add(inmueble);
            await _context.SaveChangesAsync(); // importante para que obtenga Id_inmueble generado

            // Devolver inmueble creado
            return CreatedAtAction(nameof(GetInmueble), new { id = inmueble.Id_inmueble }, inmueble);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInmueble(int id, Inmueble inmueble)
        {
            if (id != inmueble.Id_inmueble)
                return BadRequest();

            _context.Entry(inmueble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InmuebleExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInmueble(int id)
        {
            var inmueble = await _context.Inmuebles.FindAsync(id);
            if (inmueble == null)
                return NotFound();

            _context.Inmuebles.Remove(inmueble);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InmuebleExists(int id)
        {
            return _context.Inmuebles.Any(e => e.Id_inmueble == id);
        }
    }
}
