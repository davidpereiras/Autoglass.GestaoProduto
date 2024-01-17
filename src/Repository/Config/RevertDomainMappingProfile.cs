using System;
using AutoMapper;
using Domain.Domains;
using Repository.Entities;

namespace Repository.Config
{
	public class RevertDomainMappingProfile : Profile
    {
		public RevertDomainMappingProfile()
		{
            CreateMap<ProdutoDomain, ProdutoEntity>();
        }
	}
}

