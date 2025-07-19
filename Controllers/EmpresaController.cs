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
    public class EmpresaController : ControllerBase
    {
        private readonly ContextBD _context;
        private readonly IMapper _mapper;

        public EmpresaController(ContextBD context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetEmpresas()
        {
            var empresas = await _context.Empresa
                .ToListAsync();

            var resultado = _mapper.Map<List<EmpresaDTO>>(empresas);

            return Ok(resultado);
        }


        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _context.Empresa
                .FirstOrDefaultAsync(p => p.Id_empresa == id);
            
            if (empresa == null)
                return NotFound();

            return empresa;
        }

        // POST: api/Empresa
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            // Generar automáticamente Cod_ref_usuario
            var random = new Random();
            empresa.Cod_ref_empresa = "Empresa" + random.Next(100000, 999999); // 6 dígitos aleatorios
            _context.Empresa.Add(empresa);

            // 2️⃣ Hashear contraseña
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(empresa.Contraseña_empresa);

            // 3️⃣ Enviar a MongoDB
            var mongoData = new
            {
                email = empresa.Correo_empresa,
                username = empresa.Cod_ref_empresa,
                password = hashedPassword,
                fromSQL = true

            };
            var httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(mongoData), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:8800/api/auth/register", content);
            var mongoResult = await response.Content.ReadAsStringAsync();
            Console.WriteLine("📦 Respuesta de MongoDB: " + mongoResult);

            if (!response.IsSuccessStatusCode)
                return StatusCode(500, "Error al guardar en MongoDB");

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpresa), new { id = empresa.Id_empresa }, empresa);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.Id_empresa)
                return BadRequest();

            _context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
                return NotFound();

            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.Id_empresa == id);
        }
    }
}
