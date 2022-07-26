using HortifrutiSF.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Repo.Mapping
{
    public class VendaMapping : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PrecoProduto)
             .HasColumnName("Preco")
             .IsRequired();

            builder.Property(x => x.QuantidadeVenda)
            .HasColumnName("QuantidadeVenda")
            .IsRequired();

            builder.Property(x => x.ValorTotal)
            .HasColumnName("ValorTotal")
            .IsRequired();

            builder.Property(x => x.PrecoCusto)
            .HasColumnName("PrecoCusto")
            .IsRequired();

            builder.Property(x => x.DataAlteracao)
          .HasColumnName("DataCadastro");

            builder.Property(x => x.DataAlteracao)
          .HasColumnName("DataAlteracao");

            //Relacionamento
            builder.HasOne(pd => pd.Produto)
                .WithMany(v => v.Vendas)
                .HasForeignKey(pd => pd.ProdutoId);

            
        }
    }
}
