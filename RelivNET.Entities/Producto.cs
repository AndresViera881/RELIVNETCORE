namespace RelivNET.Entities
{
    public class Producto : EntityBase
    {
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; } = default!;
        public int CategoriaId { get; set; }
        public Estado Estado { get; set; } = default!;
        public int EstadoId { get; set; }
    }
}
