using System;
using Domain.Domains;
using Domain.Seletores;
using System.Collections.Generic;

namespace Domain.Interfaces.Services {

    public interface IProdutoService
    {
        void CreateProduto(ProdutoDomain produto);
        void EditProduto(ProdutoDomain produto);
        void Delete(int produtoCodigo);
        IEnumerable<ProdutoDomain> ListProdutos(ProdutoSeletor seletor);
        ProdutoDomain GetByCodigoProduto(int codigoProduto);

    }

}

