using Microsoft.EntityFrameworkCore;
using RelivNET.DataAccess;
using RelivNET.Entities;

namespace RelivNET.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private RelivNetDbContext _context;

        public CategoriaRepository(RelivNetDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Categoria categoria)
        {
            _context.Set<Categoria>().Add(categoria);
            await _context.SaveChangesAsync();
            return categoria.Id;
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await _context.Set<Categoria>().Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (entity != null)
            {
                _context.Set<Categoria>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Categoria?> FindByIdAsync(int id)
        {
            var categoria = await _context.Set<Categoria>().Where(c => c.Id == id).FirstOrDefaultAsync();
            return categoria;
        }

        public async Task<List<Categoria>> ListAsync()
        {
            var lista = await _context.Set<Categoria>().ToListAsync();
            return lista;
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Set<Categoria>().Update(categoria);
            await _context.SaveChangesAsync();
        }
    }
}
