using System;
using Application.Services;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{

    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProdutoService, ProdutoService>();
            return services;
        }
    }

}