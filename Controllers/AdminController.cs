using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppApi.Models;




namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ContextBD _context;
        private readonly IMapper _mapper;

        public AdminController(ContextBD context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdmins()
        {
            var admins = await _context.Administrador
                .ToListAsync();

            var resultado = _mapper.Map<List<Administrador>>(admins);

            return Ok(resultado);
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdmin(int id)
        {
            var admin = await _context.Administrador
                .FirstOrDefaultAsync(p => p.Id_admin_pk == id);


            if (admin == null)
                return NotFound();

            return Ok(admin);
        }


        // POST: api/Admin
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdmin(AdministradorDTO dto)
        {

            var admin = new Administrador
            {
                P_nombre = dto.P_nombre,
                S_nombre = dto.S_nombre,
                P_apellido = dto.P_apellido,
                S_apellido = dto.S_apellido,
                FechaN = dto.FechaN,
                Email = dto.Email,
                Contraseña = dto.Contraseña,
                Telefono = dto.Telefono,
                Identif_cuenta = dto.Identif_cuenta
            };

            _context.Administrador.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdmin), new { id = admin.Id_admin_pk }, admin);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, AdministradorDTO dto)
        {
            var admin = await _context.Administrador.FindAsync(id);

            if (admin == null) return NotFound();

            admin.P_nombre = dto.P_nombre;
            admin.S_nombre = dto.S_nombre;
            admin.P_apellido = dto.P_apellido;
            admin.S_apellido = dto.S_apellido;
            admin.FechaN = dto.FechaN;
            admin.Email = dto.Email;
            admin.Contraseña = dto.Contraseña;
            admin.Telefono = dto.Telefono;
            admin.Identif_cuenta = dto.Identif_cuenta;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _context.Administrador.FindAsync(id);
            if (admin == null)
                return NotFound();

            _context.Administrador.Remove(admin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminExists(int id)
        {
            return _context.Administrador.Any(e => e.Id_admin_pk == id);
        }
    }
}
