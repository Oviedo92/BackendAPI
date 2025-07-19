
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppApi.Models
{
    [Index(nameof(Cod_ref_usuario_u), IsUnique = true)]
    public class ReporteUsuario
    {
        [Key]
        public int Id_reporte { get; set; }
        public string? Tematica { get; set; }
        public string? Nombres_apellidos_u { get; set; }
        public string? Celular_u { get; set; }
        public string? Correo_u { get; set; }
        public string? Nomb_ciudad_u { get; set; }
        public string? Descripcion_queja_u { get; set; }
        public string? Cod_ref_usuario_u { get; set; }





    }

    public class ReporteUsuarioDTO
    {
        public int id_reporte { get; set; }
        public string? Tematica { get; set; }
        public string? Nombres_apellidos_u { get; set; }
        public string? Celular_u { get; set; }
        public string? Correo_u { get; set; }
        public string? Nomb_ciudad_u { get; set; }
        public string? Descripcion_queja_u { get; set; }
        public string? Cod_ref_usuario_u { get; set; }
    }
}
