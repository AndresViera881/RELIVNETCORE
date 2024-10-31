namespace RelivNET.Dto.Request
{
    public class ProductoDtoRequest
    {
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }
        public int EstadoId { get; set; }
        public string FechaCreacion { get; set; } = default!;
        public string FechaModificacion { get; set; } = default!;
    }
}
