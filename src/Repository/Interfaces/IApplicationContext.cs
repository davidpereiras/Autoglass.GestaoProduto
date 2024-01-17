using System;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.Interfaces
{
	public interface IApplicationContext
	{
        DbSet<ProdutoEntity> Produtos { get; set; }
    }
}

