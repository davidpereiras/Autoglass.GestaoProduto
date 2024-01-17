using System;
namespace Repository.Entities
{
	public class ProdutoEntity
	{
		public int CodigoProduto { get; set; }
		public string DescricaoProduto { get; set; } = null!;
		public bool SituacaoProduto { get; set; }
		public DateTime DataFabricacao { get; set; }
		public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}

