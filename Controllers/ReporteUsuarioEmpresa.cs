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
    public class ReporteUsuarioController : ControllerBase
    {
        private readonly ContextBD _context;
        private readonly IMapper _mapper;

        public ReporteUsuarioController(ContextBD context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ReporteUsuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporteUsuarioDTO>>> GetReporteUsuarios()
        {
            var reporte_usuarios = await _context.ReporteUsuario
                .ToListAsync();

            var resultado = _mapper.Map<List<ReporteUsuarioDTO>>(reporte_usuarios);

            return Ok(resultado);
        }

        // GET: api/ReporteUsuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReporteUsuario>> GetReporteUsuario(int id)
        {
            var reporte_usuario = await _context.ReporteUsuario
                .FirstOrDefaultAsync(p => p.Id_reporte == id);

            if (reporte_usuario == null)
                return NotFound();

            return reporte_usuario;
        }

        // POST: api/ReporteUsuario
        [HttpPost]
        public async Task<ActionResult<ReporteUsuario>> PostReporteUsuario(ReporteUsuario reporteUsuario)
        {

            Console.WriteLine("Llegó una queja de usuario:");

            Console.WriteLine(JsonConvert.SerializeObject(reporteUsuario));

            if (reporteUsuario == null)
            {
                return BadRequest("Los datos del reporte no son válidos.");
            }

            // Mapear el DTO a la entidad ReporteEmpresa
            var reporte = new ReporteUsuario
            {
                Tematica = reporteUsuario.Tematica,
                Nombres_apellidos_u = reporteUsuario.Nombres_apellidos_u,
                Celular_u = reporteUsuario.Celular_u,
                Correo_u = reporteUsuario.Correo_u,
                Nomb_ciudad_u = reporteUsuario.Nomb_ciudad_u,
                Descripcion_queja_u = reporteUsuario.Descripcion_queja_u,
                // Update the following line in the PostReporteUsuario method:
                Cod_ref_usuario_u = reporteUsuario.Cod_ref_usuario_u
            };

            // Guardar el reporte en la base de datos
            _context.ReporteUsuario.Add(reporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostReporteUsuario), new { id = reporte.Id_reporte }, reporte);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReporteUsuario(int id, ReporteUsuario reporteUsuario)
        {
            if (id != reporteUsuario.Id_reporte)
                return BadRequest();

            _context.Entry(reporteUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReporteUsuarioExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReporteUsuario(int id)
        {
            var reporte_usuario = await _context.ReporteUsuario.FindAsync(id);
            if (reporte_usuario == null)
                return NotFound();

            _context.ReporteUsuario.Remove(reporte_usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReporteUsuarioExists(int id)
        {
            return _context.ReporteUsuario.Any(e => e.Id_reporte == id);
        }
    }
}
