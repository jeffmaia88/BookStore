using BookStore.Data;
using BookStore.Entity;

namespace BookStore.Repositories
{
    public class EmprestimoItemRepository
    {
        private readonly BookStoreDataContext _context;

        public EmprestimoItemRepository(BookStoreDataContext context)
        {
            _context = context;
        }

        public async Task Create(EmprestimoItem item)
        {
            await _context.EmprestimoItens.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }
}
