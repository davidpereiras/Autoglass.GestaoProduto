using System;
using Domain.Domains;
using Domain.Interfaces.Services;
using Domain.Seletores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        [HttpGet("{produtoCodigo}")]
        public ActionResult GetByCodigo(int produtoCodigo)
        {
            try
            {
                return Ok(_produtoService.GetByCodigoProduto(produtoCodigo));
            }
            catch (Exception)
            {
                return BadRequest($"Não foi possível consultar produto com código {produtoCodigo}!");
            }
        }

        [HttpPost("Listar")]
        public ActionResult list([FromBody] ProdutoSeletor seletor)
        {
            try
            {
                return Ok(_produtoService.ListProdutos(seletor));
            }
            catch (Exception)
            {
                return BadRequest($"Não foi possível listar produtos!");
            }
        }

        [HttpPost("Inserir")]
        public ActionResult Insert([FromBody] ProdutoDomain produto)
        {
            try
            {
                _produtoService.CreateProduto(produto);
                return Ok($"Produto {produto.DescricaoProduto} inserido com sucesso!");
            }
            catch (Exception)
            {
                return BadRequest($"Não foi possível inserir o produto {produto.DescricaoProduto}!");
            }
        }

        [HttpPut("Editar")]
        public ActionResult Edit([FromBody] ProdutoDomain produto)
        {
            try
            {
                _produtoService.EditProduto(produto);
                return Ok($"Produto {produto.DescricaoProduto} editado com sucesso!");
            }
            catch (Exception)
            {
                return BadRequest($"Não foi possível editar o produto {produto.DescricaoProduto}!");
            }
        }

        [HttpDelete("Deletar")]
        public ActionResult Delete(int produtoCodigo)
        {
            try
            {
                _produtoService.Delete(produtoCodigo);
                return Ok($"Produto com código {produtoCodigo} foi deletado!");
            }
            catch (Exception)
            {
                return BadRequest($"Não foi possível deletar produto com código {produtoCodigo}!");
            }
        }
    }
}

