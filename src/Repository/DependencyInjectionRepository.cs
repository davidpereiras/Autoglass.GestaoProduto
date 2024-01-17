using System;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories;

namespace Repository
{

    public static class DependencyInjectionRepository
    {
        public static IServiceCollection AddPersistenceRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("GestaoProdutoDB")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            return services;
        }
    }

}