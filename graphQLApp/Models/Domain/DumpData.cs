using System.Collections.Generic;
using System.Transactions;

namespace graphQLApp.Models.Domain
{
    public class DumpData
    {
        public List<Produto> Produtos { get; set; }

        public DumpData()
        {
             Produtos.Add(new Produto()
             {
                 CodigoBarras = "0123" , Valor = 100.00 , Nome = "Prod1"
                  
             }); 
             
             Produtos.Add(new Produto()
             {
                 CodigoBarras = "01234" , Valor = 100.00 , Nome = "Prod2"
                  
             });
             
             Produtos.Add(new Produto()
             {
                 CodigoBarras = "01235" , Valor = 100.00 , Nome = "Prod3"
                  
             });
             
             
        }
        
    }
}