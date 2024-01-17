using System;
namespace Domain.Seletores {

    public enum OrderBy { ASC, DESC }

    public class ProdutoSeletor
    {
        public ProdutoSeletor()
        {
            CodigoProduto = 0;
            CodigoFornecedor = 0;
            OrderBy = "CodigoProduto";
            Pagina = 1;
            Skip = 0;
            RegistroPorPagina = 10;
            AplicarPaginacao = true;
            OrderByOrder = Seletores.OrderBy.DESC;
        }

        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public bool? SituacaoProduto { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }


        public int Pagina { get; set; }
        public int Skip { get; set; }
        public int RegistroPorPagina { get; set; }
        public bool AplicarPaginacao { get; set; }

        public string OrderBy { get; set; }

        public OrderBy OrderByOrder { get; set; }
        
    }

}


