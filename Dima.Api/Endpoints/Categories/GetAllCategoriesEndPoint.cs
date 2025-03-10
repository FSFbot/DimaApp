﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/", HandleAsync)
             .WithName("Categories: Get All Id")
             .WithSummary("Recuperar todas as categorias")
             .WithDescription("Recuperar todas as categorias").WithOrder(5)
             .Produces<PagedResponse<List<Category?>>>();

        private static async Task<IResult> HandleAsync(
            ICategoryHandler handler,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize
            )
        {
            var request = new GetAllCategoriesRequest
            {

                UserId = "Felipe@teste.io",
                PageNumber = pageNumber,
                PageSize = pageSize

            };

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
        }
    }
}

