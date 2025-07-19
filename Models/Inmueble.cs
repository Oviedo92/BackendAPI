using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppApi.Models
{
    public class Inmueble
    {
        [Key]
        public int Id_inmueble { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string? Contacto_email { get; set; }
        public string? Ubicacion { get; set; }
        public string? Identif_cuenta { get; set; } //  Identificador del usuario que creó el inmueble. Ej: User123456 o Empresa654321
        public int? Id_admin_pk { get; set; }

        [ForeignKey(nameof(Id_admin_pk))]
        public Administrador? Administrador { get; set; }
    }

    public class InmuebleDTO
    {
        public int Id_inmueble { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string? Contacto_email { get; set; }
        public string? Ubicacion { get; set; }
        public string? Tipo_propiedad { get; set; }
        public string? Identif_cuenta { get; set; }
        public int Id_admin_pk { get; set; }
    }
}
