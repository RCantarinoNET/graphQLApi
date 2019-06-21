using System.Collections;
using graphQLApp.data;
using graphQLApp.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace graphQLApp.Business
{
    public class ProdutoService
    {
        private ApplicationDBContext _context;

        public ProdutoService(ApplicationDBContext dbContext)
        {
            this._context = dbContext;
        }



        public IEnumerable<Produto> GetAll()
        {
            return _context.Produtos.OrderBy(x=> x.Nome);
        }

        public Produto Obter(string codBarras)
        {
            return _context.Produtos.FirstOrDefault(x => x.CodigoBarras == codBarras);
        }

        public IEnumerable<Produto> GetallByNome(string nome)
        {
            return _context.Produtos.Where(x => x.Nome.StartsWith(nome));
        }

        public void Incluir(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Seed()
        {
            Incluir(
                new Produto { CodigoBarras = "11111111111", Nome = "Produto01", Preco = 579 }
            );

            Incluir(
                new Produto { CodigoBarras = "2222222222", Nome = "Produto02", Preco = 579 }
            );

            Incluir(
                new Produto { CodigoBarras = "333333333333", Nome = "Produto03", Preco = 579 }
            );

            Incluir(
                new Produto { CodigoBarras = "4444444444", Nome = "Produto04", Preco = 579 }
            );

            Incluir(
                new Produto { CodigoBarras = "5555555555", Nome = "Produto05", Preco = 579 }
            );

            Incluir(
                new Produto { CodigoBarras = "66666666666", Nome = "Produto06", Preco = 579 }
            );

            Incluir(
                new Produto { CodigoBarras = "77777777777", Nome = "Produto07", Preco = 579 }
            );

            Incluir(
                new Produto { CodigoBarras = "888888888888", Nome = "Produto08", Preco = 579 }
            );

            Incluir(
                new Produto { CodigoBarras = "99999999999", Nome = "Produto09", Preco = 579 }
            );

            Incluir(
                new Produto { CodigoBarras = "10101010101010101010", Nome = "Produto10", Preco = 579 }
            );
        }
        
        
    }
}