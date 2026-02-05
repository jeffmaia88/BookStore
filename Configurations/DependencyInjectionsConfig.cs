using BookStore.Controllers;
using BookStore.Data;
using BookStore.Relatorios.EmprestimoRelatorios;
using BookStore.Relatorios.LivrosRelatorios;
using BookStore.Repositories;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BookStoreDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<LivroService>();
            services.AddScoped<EmprestimoService>();
            services.AddScoped<EstoqueService>();


            services.AddScoped<LivroRepository>();
            services.AddScoped<EmprestimoRepository>();
            services.AddScoped<EmprestimoItemRepository>();
            services.AddScoped<RelatorioEmprestimo>();
            services.AddScoped<RelatorioLivro>();

            services.AddScoped<LivroController>();
            services.AddScoped<EmprestimoController>();

            

            return services;
        }
    }
}
