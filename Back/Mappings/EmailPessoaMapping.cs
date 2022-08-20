using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Mappings
{
    public class EmailPessoaMapping : IEntityTypeConfiguration<EmailPessoa>
    {
        public void Configure(EntityTypeBuilder<EmailPessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            /* ENTITY */
            builder.Property(x => x.DataCadastro)
                .HasColumnType("datetime");

            builder.Property(x => x.DataAlteracao)
                .HasColumnType("datetime");

            builder.Property(x => x.DataExclusao)
                .HasColumnType("datetime");

            builder.ToTable("EmailPessoa");
        }
    }
}
