using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;

namespace Dima.Api.Endpoints.Transactions
{
    public class CreateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Cria uma nova categoria")
            .WithDescription("Cria uma nova categoria").WithOrder(1)
            .Produces<Core.Responses.Response<Category?>>();

        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            CreateTransactionRequest request)
        {
            request.UserId = "Felipe@teste.io";
            var result = await handler.CreateAsync(request);
            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result.Data);
        }

    }

}