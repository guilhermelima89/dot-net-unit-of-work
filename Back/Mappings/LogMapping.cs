using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Mappings;

public class LogMapping : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasColumnType("varchar(250)");

        /* ENTITY */
        builder.Property(x => x.DataCadastro)
            .HasColumnType("datetime");

        builder.Property(x => x.DataAlteracao)
            .HasColumnType("datetime");

        builder.Property(x => x.DataExclusao)
            .HasColumnType("datetime");

        builder.ToTable("Log");
    }
}
