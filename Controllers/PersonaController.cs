using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAppApi.Models;




namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ContextBD _context;
        private readonly IMapper _mapper;

        public PersonasController(ContextBD context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> GetPersonas()
        {
            var personas = await _context.Persona
                .Include(p => p.Direccion)
                //.Include(p => p.Administrador) // Incluye admin si está relacionado
                .ToListAsync();

            var resultado = _mapper.Map<List<PersonaDTO>>(personas);

            return Ok(resultado);
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Persona
                .Include(p => p.Direccion)
                //.Include(p => p.Administrador)
                .FirstOrDefaultAsync(p => p.Id_persona == id);

            if (persona == null)
                return NotFound();

            return persona;
        }

        // POST: api/Personas
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            // Generar automáticamente Cod_ref_usuario
            var random = new Random();
            persona.Cod_ref_usuario = "user" + random.Next(100000, 999999); // 6 dígitos aleatorios

            // Asignar estado inicial automáticamente
            persona.Estado = "verificado";

            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();

            // Lógica: Agregar administrador por defecto si no viene del frontend
            //if (persona.Administrador == null || !persona.Administrador.Any())
            //{
            //    persona.Administrador = new List<Administrador>
            //    {
            //        new Administrador
            //        {
            //            P_nombre = "Admin",
            //            S_nombre = "Default",
            //            P_apellido = "Sistema",
            //            S_apellido = "Control",
            //            FechaN = DateTime.Now,
            //            Email = "admin@default.com",
            //            Contraseña = "admin1234",
            //            Telefono = "0000000000",
            //        }
            //    };
            //    _context.Administrador.AddRange(persona.Administrador);
            //}

            // 2️⃣ Hashear contraseña
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(persona.Contraseña);

            // 3️⃣ Enviar a MongoDB
            var mongoData = new
            {
                email = persona.Email,
                username = persona.Cod_ref_usuario,
                password = hashedPassword,
                fromSQL   = true

            };
            var httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(mongoData), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:8800/api/auth/register", content);
            var mongoResult = await response.Content.ReadAsStringAsync();
            Console.WriteLine("📦 Respuesta de MongoDB: " + mongoResult);

            if (!response.IsSuccessStatusCode)
                return StatusCode(500, "Error al guardar en MongoDB");

            // Aquí puedes hacer lo mismo con Dirección si tienes la entidad Dirección


            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersona), new { id = persona.Id_persona }, persona);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.Id_persona)
                return BadRequest();

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
                return NotFound();

            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.Id_persona == id);
        }
    }
}
