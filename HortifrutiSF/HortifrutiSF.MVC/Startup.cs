using HortifruitiSF.Application.Application;
using HortifruitiSF.Application.Interface;
using HortifrutiSF.Domain.Repositories;
using HortifrutiSF.Repo;
using HortifrutiSF.Repo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiSF.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ProdutoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ProdutoContext>()
                .AddDefaultTokenProviders();

            //Remove padr�o de senha do Identity
            services.Configure<IdentityOptions>(options =>
                    {
                        options.Password.RequireDigit = false; //Obriga a ter um numero na senha
                                                               //options.Password.RequiredLength = 7; // valor default 8 digitos
                        options.Password.RequiredUniqueChars = 6; // minimos caracteres unicos
                        options.Password.RequireLowercase = false; // n�o � obrigat�rio come�ar com minusculo
                        options.Password.RequireNonAlphanumeric = false; // n�o � obrigat�rio alfanumerico
                        options.Password.RequireUppercase = false; // n�o � obrigatorio come�ar com maiusculo
                    });


            services.AddScoped<IProdutoApplication, ProdutoApplication>();
            services.AddScoped<IProdutoEntradaApplication, ProdutoEntradaApplication>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoEntradaRepository, ProdutoEntradaRepository>();
            services.AddScoped<IVendaApplication, VendaApplication>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IEstoqueApplication, EstoqueApplication>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
