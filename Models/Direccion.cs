using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class Direccion
    {
        [Key]
        public int Id_direccion_pk { get; set; }
        public string? Ubi_pais { get; set; }
        public string? Ubi_dire_ciudad { get; set; }
        public int PersonaId { get; set; }    


    }

    public class DireccionDTO
    {
        public int Id_direccion_pk { get; set; }
        public string? Ubi_pais { get; set; }
        public string? Ubi_dire_ciudad { get; set; }
        public int PersonaId { get; set; }
    }
}
