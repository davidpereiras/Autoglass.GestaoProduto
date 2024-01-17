using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Repository.EntityConfiguration
{
	internal class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoEntity>
	{
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.CodigoProduto);

            builder.Property(p => p.DescricaoProduto)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.DataFabricacao)
                .IsRequired();

            builder.Property(p => p.DataValidade)
              .IsRequired();

        }
    }
}

