using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    [Index(nameof(Identif_cuenta), IsUnique = true)]

    public class Administrador
    {
        [Key]
        public int Id_admin_pk { get; set; }
        public string? P_nombre { get; set; }
        public string? S_nombre { get; set; }
        public string? P_apellido { get; set; }
        public string? S_apellido { get; set; }
        public DateTime FechaN { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public string? Telefono { get; set; }
        public string? Identif_cuenta { get; set; }
        public virtual List<Inmueble>? Inmuebles { get; set; }

    }

    public class AdministradorDTO
    {
        public int Id_admin_pk { get; set; }
        public string? P_nombre { get; set; }
        public string? S_nombre { get; set; }
        public string? P_apellido { get; set; }
        public string? S_apellido { get; set; }
        public DateTime FechaN { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public string? Telefono { get; set; }
        public string? Identif_cuenta { get; set; }

        // no necesitas enviar la lista completa de inmuebles aquí

    }


}
