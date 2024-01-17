using System;
using AutoMapper;
using Domain.Domains;
using Repository.Entities;

namespace Repository.Config
{
	public class DomainMappingProfile :Profile
	{
		public DomainMappingProfile()
		{
            CreateMap<ProdutoEntity, ProdutoDomain>();
        }
	}
}

