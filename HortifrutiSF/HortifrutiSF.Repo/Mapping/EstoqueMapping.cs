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
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.QuantidadeEstoque)
             .HasColumnName("Quantidade")
             .IsRequired();

            builder.Property(x => x.DataCadastro)
             .HasColumnName("DataCadastro");

            builder.Property(x => x.DataAlteracao)
             .HasColumnName("DataAlteracao");


            //Relacionamento
            builder.HasOne(pd => pd.Produto)
                .WithMany(v => v.Estoques)
                .HasForeignKey(pd => pd.ProdutoId);
        }
    }
}
