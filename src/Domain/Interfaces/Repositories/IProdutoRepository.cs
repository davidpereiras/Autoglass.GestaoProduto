using System;
using Domain.Domains;
using System.Threading;
using System.Threading.Tasks;
using Domain.Seletores;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
	public interface IProdutoRepository 
	{
        void CreateProduto(ProdutoDomain produtoDomain);
        void EditProduto(ProdutoDomain produtoDomain);
        void Delete(int produtoCodigo);
        ProdutoDomain GetByCodigoProduto(int produtoCodigo);
        IEnumerable<ProdutoDomain> GetList(ProdutoSeletor seletor);
    }
}

