using GraphQL.Types;

namespace graphQLApp.Models.QL
{
    public class ProdutoType : ObjectGraphType<Domain.Produto>
    {
        public ProdutoType()
        {
            Name = "Produto";
            
            Field(x => x.Nome).Description("Nome do produto");
            Field(x => x.CodigoBarras).Description("codigo de barras do produto");
            Field(x => x.Preco).Description("valor do produto");

        }
        
    }
}