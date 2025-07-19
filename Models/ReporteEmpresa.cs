using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppApi.Models
{
    public class ReporteEmpresa
    {
        [Key]
        public int Id_reporte { get; set; }
        public string? Tematica { get; set; }
        public string? Nombres_apellidos { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Nomb_ciudad { get; set; }
        public string? Descripcion_queja { get; set; }
        public string? Cod_ref_empresa { get; set; }


    }


    public class ReporteEmpresaDTO
    {
        public int Id_reporte { get; set; }
        public string? Tematica { get; set; }
        public string? Nombres_apellidos { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Nomb_ciudad { get; set; }
        public string? Descripcion_queja { get; set; }
        public string? Cod_ref_empresa { get; set; }





    }
}