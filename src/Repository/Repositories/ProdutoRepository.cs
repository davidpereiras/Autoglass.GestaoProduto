using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Domain.Domains;
using Domain.Interfaces.Repositories;
using Domain.Seletores;
using Repository.Context;
using Repository.Entities;

using Repository.Interfaces;

namespace Repository.Repositories
{

    public sealed class ProdutoRepository : IProdutoRepository
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public ProdutoRepository(ApplicationContext applicationContext, IMapper mapper)
        {
            _context = applicationContext;
            _mapper = mapper;
        }

        public void CreateProduto(ProdutoDomain produtoDomain)
        {
            ProdutoEntity produtoEntity = _mapper.Map<ProdutoEntity>(produtoDomain);
            _context.Produtos.Add(produtoEntity);
        }

        public void EditProduto(ProdutoDomain produtoDomain)
        {
            var produtoEntity = _mapper.Map<ProdutoEntity>(produtoDomain);
            _context.Produtos.Update(produtoEntity);
        }

        public ProdutoDomain GetByCodigoProduto(int produtoCodigo)
        {
            var produtoEntity = _context.Produtos.Where(x => x.CodigoProduto.Equals(produtoCodigo)).FirstOrDefault();

            return _mapper.Map<ProdutoDomain>(produtoEntity);
        }

        public void Delete(int produtoCodigo)
        {
            var produtoEntity = _context.Produtos.Find(produtoCodigo);
            produtoEntity.SituacaoProduto = false;

            _context.Produtos.Update(produtoEntity);
        }

        public IEnumerable<ProdutoDomain> GetList(ProdutoSeletor seletor)
        {
            IQueryable<ProdutoEntity> query = _context.Produtos; ;

            query = CreateParameters(seletor, query);
            query = CreateOrder(seletor, query);
            query = CreateLimit(seletor, query);

            return query.Select(x => _mapper.Map<ProdutoDomain>(x)).ToList();
        }

        private IQueryable<ProdutoEntity> CreateParameters(ProdutoSeletor seletor, IQueryable<ProdutoEntity> query)
        {
            query = query.Where(x => x.SituacaoProduto);

            if (seletor.CodigoProduto > 0)
                query = query.Where(x => x.CodigoProduto.Equals(seletor.CodigoProduto));

            if (seletor.CodigoFornecedor > 0)
                query = query.Where(x => x.CodigoFornecedor.Equals(seletor.CodigoFornecedor));

            if (!string.IsNullOrEmpty(seletor.DescricaoProduto))
                query = query.Where(x => x.DescricaoProduto.Contains(seletor.DescricaoProduto));

            if (!string.IsNullOrEmpty(seletor.DescricaoFornecedor))
                query = query.Where(x => x.DescricaoFornecedor.Contains(seletor.DescricaoFornecedor));

            if (!string.IsNullOrEmpty(seletor.CNPJFornecedor))
                query = query.Where(x => x.CNPJFornecedor.Contains(seletor.CNPJFornecedor));

            if (seletor.SituacaoProduto != null)
                query = query.Where(x => x.DescricaoProduto.Contains(seletor.DescricaoProduto));

            if (seletor.DataFabricacao != DateTime.MinValue)
                query = query.Where(x => x.DataFabricacao == seletor.DataFabricacao);

            if (seletor.DataValidade != DateTime.MinValue)
                query = query.Where(x => x.DataValidade == seletor.DataValidade);

            return query;
        }

        private IQueryable<ProdutoEntity> CreateLimit(ProdutoSeletor seletor, IQueryable<ProdutoEntity> query)
        {
            if (!seletor.AplicarPaginacao)
                return query;

            if (seletor.Pagina < 0)
                seletor.Pagina = 1;

            int skip = (seletor.Pagina - 1) * seletor.RegistroPorPagina;
            int take = seletor.RegistroPorPagina;

            return query.Skip(skip).Take(take).AsQueryable();
        }

        private IQueryable<ProdutoEntity> CreateOrder(ProdutoSeletor seletor, IQueryable<ProdutoEntity> query)
        {
            try
            {
                if (seletor.OrderBy != null)
                {
                    query = query.OrderBy(y => 1);

                    string[] fields = seletor.OrderBy.Split(',');

                    foreach (string fieldWithOrder in fields)
                    {

                        string[] fieldParam = fieldWithOrder.Split(' ');

                        OrderBy order = fieldParam.Length > 1 ? (OrderBy)Enum.Parse(typeof(OrderBy), fieldParam[1]) : seletor.OrderByOrder;

                        string orderBy = "ThenBy";
                        if (order == OrderBy.DESC)
                        {
                            orderBy = "ThenByDescending";
                        }

                        ParameterExpression x = Expression.Parameter(query.ElementType, "x");
                        Expression body = x;

                        foreach (var member in fieldParam[0].Trim().Split('.'))
                            body = Expression.PropertyOrField(body, member);

                        LambdaExpression exp = Expression.Lambda(body, x);
                        query = (IQueryable<ProdutoEntity>)query.Provider.CreateQuery(Expression.Call(typeof(Queryable), orderBy, new Type[] {
                            query.ElementType, exp.Body.Type
                        }, query.Expression, exp));
                    }
                }
            }
            catch { }

            return query.AsQueryable();
        }

    }
}

