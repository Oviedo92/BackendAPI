using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAppApi.Models;




namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteEmpresaController : ControllerBase
    {
        private readonly ContextBD _context;
        private readonly IMapper _mapper;

        public ReporteEmpresaController(ContextBD context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ReporteEmpresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporteEmpresaDTO>>> GetReporteEmpresas()
        {
            var reporte_empresa = await _context.ReporteEmpresa
                .ToListAsync();
            
            var resultado = _mapper.Map<List<ReporteEmpresaDTO>>(reporte_empresa);

            return Ok(resultado);
        }

        // GET: api/ReporteEmpresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReporteEmpresa>> GetReporteEmpresa(int id)
        {
            var reporte_empresa = await _context.ReporteEmpresa
        .FirstOrDefaultAsync(p => p.Id_reporte == id);

            if (reporte_empresa == null)
                return NotFound();

            var dto = new ReporteEmpresaDTO
            {
                Id_reporte = reporte_empresa.Id_reporte,
                Tematica = reporte_empresa.Tematica,
                Nombres_apellidos = reporte_empresa.Nombres_apellidos,
                Celular = reporte_empresa.Celular,
                Correo = reporte_empresa.Correo,
                Nomb_ciudad = reporte_empresa.Nomb_ciudad,
                Descripcion_queja = reporte_empresa.Descripcion_queja,
                Cod_ref_empresa = reporte_empresa.Cod_ref_empresa
            };

            return Ok(dto);
        }

        // Update the property assignment in the PostReporteEmpresa method to fix the type mismatch.
        [HttpPost]
        public async Task<ActionResult<ReporteEmpresa>> PostReporteEmpresa(ReporteEmpresa reporteEmpresa)
        {
            if (reporteEmpresa == null)
            {
                return BadRequest("Los datos del reporte no son válidos.");
            }

            // Mapear el DTO a la entidad ReporteEmpresa
            var reporte = new ReporteEmpresa
            {
                Tematica = reporteEmpresa.Tematica,
                Nombres_apellidos = reporteEmpresa.Nombres_apellidos,
                Celular = reporteEmpresa.Celular,
                Correo = reporteEmpresa.Correo,
                Nomb_ciudad = reporteEmpresa.Nomb_ciudad,
                Descripcion_queja = reporteEmpresa.Descripcion_queja,
                Cod_ref_empresa = reporteEmpresa.Cod_ref_empresa
            };

            // Guardar el reporte en la base de datos
            _context.ReporteEmpresa.Add(reporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostReporteEmpresa), new { id = reporte.Id_reporte }, reporte);
        }

        // Correct the typo in the PUT method where the error occurs
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReporteEmpresa(int id, ReporteEmpresaDTO dto)
        {
            if (id != dto.Id_reporte)
                return BadRequest();

            // Buscar el reporte de la empresa existente
            var reporteEmpresa = await _context.ReporteEmpresa.FindAsync(id);
            if (reporteEmpresa == null)
                return NotFound();

            // Asignar los valores recibidos en el DTO al objeto de entidad
            reporteEmpresa.Tematica = dto.Tematica;
            reporteEmpresa.Nombres_apellidos = dto.Nombres_apellidos;
            reporteEmpresa.Celular = dto.Celular;
            reporteEmpresa.Correo = dto.Correo;
            reporteEmpresa.Nomb_ciudad = dto.Nomb_ciudad;
            reporteEmpresa.Descripcion_queja = dto.Descripcion_queja;
            reporteEmpresa.Cod_ref_empresa = dto.Cod_ref_empresa; // Fix the typo: replace '.' with ';'

            // Marcar el estado de la entidad como modificada
            _context.Entry(reporteEmpresa).State = EntityState.Modified;

            try
            {
                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReporteEmpresaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent(); // Retornar un código de estado 204 si la operación es exitosa
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReporteEmpresa(int id)
        {
            // Buscar el reporte de la base de datos
            var reporte_empresa = await _context.ReporteEmpresa.FindAsync(id);

            // Si no encontramos el reporte, devolver un error
            if (reporte_empresa == null)
                return NotFound();

            // Eliminar el reporte de la base de datos
            _context.ReporteEmpresa.Remove(reporte_empresa);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            return NoContent(); // Retornamos una respuesta sin contenido, indicando éxito.
        }

        private bool ReporteEmpresaExists(int id)
        {
            return _context.ReporteEmpresa.Any(e => e.Id_reporte == id);
        }
    }
}
