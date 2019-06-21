using System;
using System.Net.Http;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using graphQLApp.Business;
using graphQLApp.data;
using graphQLApp.Models.Domain;
using graphQLApp.QLQueries;
using Microsoft.AspNetCore.Mvc;


namespace graphQLApp.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _executer;
        private readonly ISchema _schema;

        public GraphQLController(IDocumentExecuter executer, ISchema schema)
        {
            this._executer = executer;
            this._schema = schema;
        }
        
        

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QLQueries.GraphQLQuery query)
        {

            if (query == null)
                throw new ArgumentException("query null");

            var inputs = query.Variables.ToInputs();
            var exec = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _executer.ExecuteAsync(exec)
                .ConfigureAwait(false);
           
                /*
            var schema = new Schema()
            {
                Query = new QLQueries.EatMoreQuery(_context)
            };

            var result = await new DocumentExecuter()
                .ExecuteAsync(_ =>
                {
                    _.Schema = schema;
                    _.Query = hands.Query;
                    _.OperationName = hands.OperationName;
                    _.Inputs = input;
                });
*/
            if (result.Errors?.Count > 0)
                return BadRequest();


            return Ok(result);
        }

    }
}