using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {

        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(o => o.Id);
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}
