using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {

        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataLancamento).IsRequired();

            builder.HasOne(x => x.Autor).WithMany(s => s.Livros)
                 .HasForeignKey(x => x.IdAutor);
        }
    }
}
