using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasData(
                new Pessoa
                {
                    Id = 1,
                    Nome = "PESSOA DE TESTE",
                    DataCadastro = DateTime.Now
                }
            );

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
