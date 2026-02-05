using BookStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Mappings
{
    public class EmprestimoItemMapping : IEntityTypeConfiguration<EmprestimoItem>
    {
        public void Configure(EntityTypeBuilder<EmprestimoItem> builder)
        {
            builder.ToTable("EmprestimoItem");
            builder.HasKey(ei => ei.Id);
            builder.Property(ei => ei.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(ei => ei.EmprestimoId).IsRequired();
            builder.Property(ei => ei.LivroId).IsRequired();
            builder.Property(ei => ei.Quantidade).IsRequired().HasColumnType("INT");

            builder.HasIndex(ei => new { ei.EmprestimoId, ei.LivroId }).IsUnique();

        }
    }

}
