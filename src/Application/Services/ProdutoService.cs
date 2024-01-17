using System;
using System.Collections.Generic;
using Domain.Domains;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Seletores;
using Repository.Interfaces;

namespace Application.Services
{

    public sealed class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public ProdutoDomain GetByCodigoProduto(int produtoCodigo)
            => _produtoRepository.GetByCodigoProduto(produtoCodigo);

        public IEnumerable<ProdutoDomain> ListProdutos(ProdutoSeletor seletor)
            => _produtoRepository.GetList(seletor);


        public void CreateProduto(ProdutoDomain produto)
        {
            _produtoRepository.CreateProduto(produto);
            _unitOfWork.Commit();
        }

        public void EditProduto(ProdutoDomain produto)
        {
            _produtoRepository.EditProduto(produto);
            _unitOfWork.Commit();
        }

        public void Delete(int produtoCodigo)
        {
            _produtoRepository.Delete(produtoCodigo);
            _unitOfWork.Commit();
        }

    }


}