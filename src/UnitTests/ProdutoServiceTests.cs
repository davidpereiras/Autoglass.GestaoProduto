using Application.Services;
using Domain.Domains;
using Moq;
using Xunit;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Repository.Interfaces;
using System.Collections.Generic;
using Domain.Seletores;
using System.Linq;
using System;
using Repository.Repositories;

namespace UnitTests
{
    public class ProdutoServiceTests
    {
        #region Fields
        private readonly IProdutoService _produtoService;
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        #endregion

        #region Ctor
        public ProdutoServiceTests()
        {

            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();

            _produtoService = new ProdutoService(
                _produtoRepositoryMock.Object,
                _unitOfWork.Object
            );

        }
        #endregion

        #region Tests
        [Fact]
        public void BuscaPorCodigoProduto_QunandoCodigoProdutoValido_ReturnsSuccess()
        {
            //Arrange
            int codigoProduto = 1;
            var produto = new ProdutoDomain();

            _produtoRepositoryMock.Setup(x => x.GetByCodigoProduto(
                It.IsAny<int>()))
                .Returns(produto);

            //Act
            var domain = _produtoService.GetByCodigoProduto(codigoProduto);

            //Assert 
            Assert.NotNull(domain);
        }

        [Fact]
        public void BuscaPorCodigoProduto_QunandoCodigoProdutoInValido_ReturnsSuccess()
        {
            //Arrange
            int codigoProduto = 1;
            ProdutoDomain produto = null;

            _produtoRepositoryMock.Setup(x => x.GetByCodigoProduto(
                It.IsAny<int>()))
                .Returns(produto);

            //Act
            var domain = _produtoService.GetByCodigoProduto(codigoProduto);

            //Assert 
            Assert.Null(domain);
        }

        [Fact]
        public void ListaProduto_Semfiltros_ReturnsSuccess()
        {
            //Arrange
            ProdutoSeletor seletor = new ProdutoSeletor();
            List<ProdutoDomain> ListProduto = new List<ProdutoDomain>
            {
                new ProdutoDomain { CodigoProduto = 1 },
                new ProdutoDomain { CodigoProduto = 2 },
                new ProdutoDomain { CodigoProduto = 3 }
            };

            _produtoRepositoryMock.Setup(x => x.GetList(
                It.IsAny<ProdutoSeletor>()))
                .Returns(ListProduto);

            //Act
            List<ProdutoDomain> result = _produtoService.ListProdutos(seletor).ToList();

            //Assert 
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void ListaProduto_Comfiltros_ReturnsSuccess()
        {
            //Arrange
            ProdutoSeletor seletor = new ProdutoSeletor { DescricaoProduto = "Produto segundo" };
            List<ProdutoDomain> ListProduto = new List<ProdutoDomain>
            {
                new ProdutoDomain { DescricaoProduto = "Produto primeiro" },
                new ProdutoDomain { DescricaoProduto = "Produto segundo" },
                new ProdutoDomain { DescricaoProduto = "Produto terceiro" }
            };

            _produtoRepositoryMock.Setup(x => x.GetList(
                It.IsAny<ProdutoSeletor>()))
                .Returns(ListProduto);

            //Act
            List<ProdutoDomain> result = _produtoService.ListProdutos(seletor).ToList();

            //Assert 
            Assert.NotNull(result.FirstOrDefault(x => x.DescricaoProduto == "Produto segundo"));
        }

        [Fact]
        public void InserirProduto_QuandoProdutoValido_ReturnsSuccess()
        {
            //Arrange
            var produtoInserir = new ProdutoDomain
            {
                DescricaoProduto = "Produto",
                SituacaoProduto = true,
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(1),
                CodigoFornecedor = 1,
                DescricaoFornecedor = "Fornecedor",
                CNPJFornecedor = "CNPJ Fornecedor" 
            };
            _produtoRepositoryMock.Setup(x => x.CreateProduto(
                It.IsAny<ProdutoDomain>()));

            //Act
            _produtoService.CreateProduto(produtoInserir);

            //Assert 
            _produtoRepositoryMock.Verify(repo => repo.CreateProduto(It.IsAny<ProdutoDomain>()), Times.Once);
        }

        [Fact]
        public void DeletarProduto_QuandoProdutoValido_ReturnsSuccess()
        {
            //Arrange
            int produtoCodigo = 1;
            var produtoRetorno = new ProdutoDomain
            {
                SituacaoProduto = false
            };


            _produtoRepositoryMock.Setup(x => x.Delete(
                It.IsAny<int>()));

            //Act
            _produtoService.Delete(produtoCodigo);

            //Assert 
            _produtoRepositoryMock.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
        }
        #endregion
    }
}

