using HortifrutiSF.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HortifrutiSF.Repo.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
              .HasColumnName("Nome")
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(x => x.Descricao)
              .HasColumnName("Descricao")
              .IsRequired();

            builder.Property(x => x.DataCadastro)
             .HasColumnName("DataCadastro");

            builder.Property(x => x.DataAlteracao)
           .HasColumnName("DataAlteracao");


           
        }
    }
}
