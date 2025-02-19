using Dima.Api.Common.Api;
using Dima.Api.Endpoints.Categories;
using Dima.Api.Endpoints.Transactions;

namespace Dima.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");

        var categoryEndpoints = endpoints.MapGroup("v1/categories")
            .WithTags("Categories");
        //.RequireAuthorization();

        categoryEndpoints.MapEndpoint<CreateCategoryEndpoint>();
        categoryEndpoints.MapEndpoint<UpdateCategoryEndpoint>();
        categoryEndpoints.MapEndpoint<DeleteCategoryEndpoint>();
        categoryEndpoints.MapEndpoint<GetCategoryByIdEndpoint>();
        categoryEndpoints.MapEndpoint<GetAllCategoriesEndpoint>();

        var transactionEndpoints = endpoints.MapGroup("v1/transactions")
            .WithTags("Transactions");
        //.RequireAuthorization();

        transactionEndpoints.MapEndpoint<CreateTransactionEndpoint>();
        transactionEndpoints.MapEndpoint<UpdateTransactionEndpoint>();
        transactionEndpoints.MapEndpoint<DeleteTransactionEndpoint>();
        transactionEndpoints.MapEndpoint<GetTransactionByIdEndpoint>();
        transactionEndpoints.MapEndpoint<GetTransactionByPeriodEndpoint>();
    }

    private static void MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
    }
}
