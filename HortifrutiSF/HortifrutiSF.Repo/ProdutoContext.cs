using HortifrutiSF.Domain.Entidade;
using Microsoft.EntityFrameworkCore;


namespace HortifrutiSF.Repo
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {

        }

        public ProdutoContext()
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoEntrada> ProdutoEntradas { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Estoque> Estoques { get; set;}
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoContext).Assembly);
        }


    }


}
