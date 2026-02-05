using BookStore.Entity;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class LivroRepository
    {
        private readonly BookStoreDataContext _context;

        public LivroRepository(BookStoreDataContext bookStoreContext)
        {
            _context = bookStoreContext;
        }

        public async Task Create(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
        }

        public async Task<Livro?> GetById (int id)
        {
            return await _context.Livros.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Livro>> GetAll()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task Update (Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }

        public async Task Delete (Livro livro)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }


    }
}
