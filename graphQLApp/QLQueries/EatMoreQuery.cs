using System;
using System.Collections.Generic;
using GraphQL.Types;
using graphQLApp.Models.QL;
using System.Linq;
using graphQLApp.data;

namespace graphQLApp.QLQueries
{
    public class EatMoreQuery : ObjectGraphType
    {
        public EatMoreQuery(ApplicationDBContext data)
        {
            Field<ListGraphType<ProdutoType>>("produtos",
                resolve: context =>
                {
                    var produtos = data.Produtos;
                    return produtos;
                });
            
            
            Field<ProdutoType>(
                "produto",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "codigoDeBarras", Description = "Código do produto" }),
                resolve: context =>
                {
                    var codigoDeBarras = context.GetArgument<string>("codigoDeBarras");
                    var produto = data
                        .Produtos
                        .FirstOrDefault(i => i.CodigoBarras == codigoDeBarras);
                    return produto;
                });
        }
    }
}