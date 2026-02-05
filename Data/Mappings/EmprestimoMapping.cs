using BookStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Mappings
{
    public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd().UseIdentityColumn();


            builder.Property(e => e.Codigo).IsRequired().HasColumnType("int");
            builder.Property(e => e.DataEmprestimo).IsRequired().HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.DataDevolucaoPrevista).IsRequired().HasColumnType("DATETIME");
            builder.Property(e => e.DataDevolucao).IsRequired().HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()");            
            builder.HasIndex(e => e.Codigo, "IX_Emprestimo_Codigo").IsUnique();


        }
    }
}
