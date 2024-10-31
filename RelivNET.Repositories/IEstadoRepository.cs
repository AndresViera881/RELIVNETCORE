using RelivNET.Entities;

namespace RelivNET.Repositories
{
    public interface IEstadoRepository
    {
        Task<List<Estado>> ListAsync();
        Task<int> AddAsync(Estado estado);
        Task<Estado?> FindByIdAsync(int id);
        Task UpdateAsync(Estado estado);
        Task DeleteAsync(int Id);
    }
}
