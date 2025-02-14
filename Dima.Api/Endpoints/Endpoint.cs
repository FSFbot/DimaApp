using Dima.Api.Common.Api;

namespace Dima.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app
            .MapGroup("");

        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
            .RequireAuthorization()
            .MapEndpoint<>();
    }

    private static void MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
    }
}