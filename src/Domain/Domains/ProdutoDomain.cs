using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domain.Domains
{
    public class ProdutoDomain : IValidatableObject
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = null!;
        public bool SituacaoProduto { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataFabricacao == DateTime.MinValue)
            {
                yield return new ValidationResult("A Data de fabricação é obrigatória.", new[] { nameof(DataFabricacao) });
            }

            if (DataFabricacao >= DataValidade)
                yield return new ValidationResult("Data fabricação não pode ser maior ou igual a data de validade.", new[] { nameof(DataFabricacao) });

        }

    }
}

