namespace RelivNET.Dto.Response
{
    public class ProductoDtoResponse
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }
    }
}
