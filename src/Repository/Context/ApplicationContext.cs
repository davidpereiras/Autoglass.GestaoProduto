using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Repository.Context
{
	public class ApplicationContext : DbContext, IApplicationContext
    {
        private readonly IConfiguration configuration;
    
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }
        public Task<int> SaveChangesAsync()
            => base.SaveChangesAsync();

        public virtual DbSet<ProdutoEntity> Produtos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
     }
}

