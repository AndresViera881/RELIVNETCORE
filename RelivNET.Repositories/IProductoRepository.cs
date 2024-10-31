using Microsoft.EntityFrameworkCore.Infrastructure;
using RelivNET.Entities;
using RelivNET.Entities.infos;

namespace RelivNET.Repositories
{
    public interface IProductoRepository
    {
        Task<ICollection<ProductoInfo>> ListAsync();
        Task<int> AddAsync(Producto producto);
        Task<Producto?> FindByIdAsync(int id);
        Task UpdateAsync(Producto producto);
        Task DeleteAsync(int Id);
    }
}
