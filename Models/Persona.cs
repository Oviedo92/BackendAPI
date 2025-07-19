using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class Persona
    {
        [Key]
        public int Id_persona { get; set; }
        public string? Cc_id_usuario { get; set; }
        public string? P_nombre { get; set; }
        public string? S_nombre { get; set; }
        public string? P_apellido { get; set; }
        public string? S_apellido { get; set; }
        public DateTime FechaN { get; set; }
        public string? Sexo { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public string? Telefono { get; set; }
        public string? Despc_interes { get; set; }
        public string? Detail_perfil_persona { get; set; }
        public string? Estado { get; set; }
        public string? Cod_ref_usuario { get; set; }
        //public virtual List<Administrador>? Administrador { get; set; }
        public virtual List<Direccion>? Direccion { get; set; }

    }
    public class PersonaDTO
    {

        public int Id_persona { get; set; }
        public string? Cc_id_usuario { get; set; }
        public string? P_nombre { get; set; }
        public string? S_nombre { get; set; }
        public string? P_apellido { get; set; }
        public string? S_apellido { get; set; }
        public DateTime FechaN { get; set; }
        public string? Sexo { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public string? Telefono { get; set; }
        public string? Despc_interes { get; set; }
        public string? Detail_perfil_persona { get; set; }
        public string? Estado { get; set; }
        public string? Cod_ref_usuario { get; set; }

        //public virtual List<AdministradorDTO>? Administrador { get; set; }
        public virtual List<DireccionDTO>? Direccion { get; set; }

    }
}
