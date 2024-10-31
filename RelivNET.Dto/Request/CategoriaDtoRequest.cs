using System.ComponentModel.DataAnnotations;

namespace RelivNET.Dto.Request
{
    public class CategoriaDtoRequest
    {
        [Required]
        public string Descripcion { get; set; } = default!;
    }
}
