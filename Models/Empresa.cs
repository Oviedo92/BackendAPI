using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class Empresa
    {
        [Key]
        public int Id_empresa { get; set; } 
        public int NIT_empresa { get; set; }
        public DateTime? Fecha_origen { get; set; }
        public string? Correo_empresa { get; set; }
        public string? Contraseña_empresa { get; set; }
        public string? Interes_empresa { get; set; }
        public string? Descripcion_Empres { get; set; }
        public string? Telefono_empresa { get; set; }
        public string? Pais_empresa { get; set; }
        public string? Ciudad_empresa { get; set; }
        public string? Cod_ref_empresa { get; set; }






    }

    public class EmpresaDTO
    {
        public int Id_empresa { get; set; }
        public int NIT_empresa { get; set; }
        public DateTime? Fecha_origen { get; set; }
        public string? Correo_empresa { get; set; }
        public string? Contraseña_empresa { get; set; }
        public string? Interes_empresa { get; set; }
        public string? Descripcion_Empres { get; set; }
        public string? Telefono_empresa { get; set; }
        public string? Pais_empresa { get; set; }
        public string? Ciudad_empresa { get; set; }
        public string? Cod_ref_empresa { get; set; }
     


    }
}
