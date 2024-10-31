using Microsoft.EntityFrameworkCore;
using RelivNET.DataAccess;
using RelivNET.Entities;
using RelivNET.Entities.infos;

namespace RelivNET.Repositories
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly RelivNetDbContext _context;

        public ProductoRepository(RelivNetDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Producto producto)
        {
            await _context.Set<Producto>().AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto.Id;
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await _context.Set<Producto>().Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (entity != null)
            {
                _context.Set<Producto>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Producto?> FindByIdAsync(int id)
        {
            var producto = await _context.Set<Producto>().Include(p => p.Categoria).Include(p => p.Estado).Where(c => c.Id == id).FirstOrDefaultAsync();
            return producto;
        }

        public async Task<ICollection<ProductoInfo>> ListAsync()
        {
            var lista = await _context.Set<Producto>().Select(p => new ProductoInfo

            {
                Id = p.Id,
                Nombre = p.Nombre!,
                Precio = p.Precio,
                Stock = p.Stock,
                Categoria = p.Categoria,
                Estado = p.Estado
            }

       ).ToListAsync();
            return lista;

        }

        public async Task UpdateAsync(Producto producto)
        {
            _context.Set<Producto>().Update(producto);
            await _context.SaveChangesAsync();
        }

        
    }
}
