using BookStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(l=> l.Titulo).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(200);
            builder.Property(l => l.Autor).HasColumnType("NVARCHAR").HasMaxLength(100);
            builder.Property(l => l.Isbn).IsRequired().HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(l => l.AnoPublicacao).IsRequired().HasColumnType("DATE");
            builder.Property(l => l.Editora).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(100);
            builder.Property(l => l.Quantidade).IsRequired().HasColumnType("INT");
            builder.Property(l => l.DataCadastro).IsRequired().HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()");

            builder.HasIndex(l=> l.Isbn, "IX_Livro_Isbn").IsUnique();




        }
    }
} 
