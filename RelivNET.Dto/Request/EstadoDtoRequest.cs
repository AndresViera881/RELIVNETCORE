using System.ComponentModel.DataAnnotations;

namespace RelivNET.Dto.Request
{
    public class EstadoDtoRequest
    {
        [Required]
        public string Descripcion { get; set; } = default!;
    }
}
