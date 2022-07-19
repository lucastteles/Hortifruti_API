using HortifrutiSF.Domain.Entidade;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HortifrutiSF.Repo
{
    public class ProdutoContext : IdentityDbContext<IdentityUser>
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
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating.ApplyConfigurationsFromAssembly(typeof(ProdutoContext).Assembly);
        //}






    }


}
