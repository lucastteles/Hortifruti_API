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

        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoEntrada> ProdutoEntradas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoContext).Assembly);
        }


    }


}
