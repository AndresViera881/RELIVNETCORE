using Microsoft.EntityFrameworkCore;
using RelivNET.DataAccess;
using RelivNET.Entities;

namespace RelivNET.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {

        private RelivNetDbContext _context;

        public EstadoRepository(RelivNetDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Estado estado)
        {
            _context.Set<Estado>().Add(estado);
            await _context.SaveChangesAsync();
            return estado.Id;
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await _context.Set<Estado>().Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (entity != null)
            {
                _context.Set<Estado>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Estado?> FindByIdAsync(int id)
        {
            var estado = await _context.Set<Estado>().Where(c => c.Id == id).FirstOrDefaultAsync();
            return estado;
        }

        public async Task<List<Estado>> ListAsync()
        {
            var lista = await _context.Set<Estado>().ToListAsync();
            return lista;
        }

        public async Task UpdateAsync(Estado estado)
        {
            _context.Set<Estado>().Update(estado);
            await _context.SaveChangesAsync();
        }
    }
}
