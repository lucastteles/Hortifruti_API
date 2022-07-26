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
    public class ProdutoEntradaMapping : IEntityTypeConfiguration<ProdutoEntrada>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntrada> builder)
        {
            builder.ToTable("ProdutoEntrada");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Preco)
             .HasColumnName("Preço")
             .IsRequired();

            builder.Property(x => x.Quantidade)
              .HasColumnName("Quantidade")
              .IsRequired();

            builder.Property(x => x.PrecoCusto)
           .HasColumnName("PrecoCusto")
           .IsRequired();

            builder.Property(x => x.Peso)
             .HasColumnName("Peso")
             .IsRequired();

            builder.Property(x => x.DataCadastro)
             .HasColumnName("DataCadastro");

            builder.Property(x => x.DataAlteracao)
           .HasColumnName("DataAlteracao");

            builder.Property(x => x.Fornecedor)
          .HasColumnName("Fornecedor");

            
        }
    }
}
