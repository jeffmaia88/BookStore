using BookStore.Data.Mappings;
using BookStore.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreDataContext : DbContext    
    {
        public BookStoreDataContext(DbContextOptions<BookStoreDataContext> options) : base(options)
        {
            
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<EmprestimoItem> EmprestimoItens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMapping());
            modelBuilder.ApplyConfiguration(new EmprestimoMapping());
            modelBuilder.ApplyConfiguration(new EmprestimoItemMapping());

        }


    }
}
