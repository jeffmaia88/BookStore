using BookStore.Entity;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class EmprestimoRepository
    {
        private readonly BookStoreDataContext _context;

        public EmprestimoRepository(BookStoreDataContext bookStoreContext)
        {
            _context = bookStoreContext;
        }

        public async Task Create(Emprestimo emprestimo)
        {
            await _context.Emprestimos.AddAsync(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task<Emprestimo?> GetById(int id)
        {
            return await _context.Emprestimos
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Emprestimo?> GetByCodigo(int codigo)
        {
            return await _context.Emprestimos
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Codigo == codigo);
        }

        public async Task<List<Emprestimo>> GetAll()
        {
            return await _context.Emprestimos
                .AsNoTracking()
                .OrderByDescending(e => e.DataEmprestimo)
                .ToListAsync();
        }

        public async Task<int> GetUltimoCodigo()
        {
            var existeEmprestimo = await _context.Emprestimos.AnyAsync();

            if (!existeEmprestimo)
                return 0;

            return await _context.Emprestimos.MaxAsync(e => e.Codigo);
        }


        public async Task Update(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Emprestimo emprestimo)
        {
            _context.Emprestimos.Remove(emprestimo);
            await _context.SaveChangesAsync();
        }
    }
}
