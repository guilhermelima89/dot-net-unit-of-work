using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Mappings
{
    public class TelefonePessoaMapping : IEntityTypeConfiguration<TelefonePessoa>
    {
        public void Configure(EntityTypeBuilder<TelefonePessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasColumnType("varchar(50)");

            /* ENTITY */
            builder.Property(x => x.DataCadastro)
                .HasColumnType("datetime");

            builder.Property(x => x.DataAlteracao)
                .HasColumnType("datetime");

            builder.Property(x => x.DataExclusao)
                .HasColumnType("datetime");

            builder.ToTable("Pessoa");
        }
    }
}
