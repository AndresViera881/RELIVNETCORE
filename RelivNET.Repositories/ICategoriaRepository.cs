using RelivNET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelivNET.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ListAsync();
        Task<int> AddAsync(Categoria categoria);
        Task<Categoria?> FindByIdAsync(int id);
        Task UpdateAsync(Categoria categoria);
        Task DeleteAsync(int Id);
    }
}
