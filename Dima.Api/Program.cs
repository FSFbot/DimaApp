using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x=> x.CustomSchemaIds(n=> n.FullName));

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x=> x.UseSqlServer(cnnStr));
var app = builder.Build( );

app.UseSwagger();
app.UseSwaggerUI();
    

//Request - Requisição  GET, POST, PUT e DELETE 
// Obter, Criar, Atualizar, Deletar
// Get - Não tem corpo; ja os outros normalmente possuem Json como corpo
app.MapPost(
    "/v1/categories",
   async (CreateCategoryRequest request, ICategoryHandler handler) 
        =>await handler.CreateAsync(request)) 
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<Response<Category?>>();

app.MapPut(
        "/v1/categories/{id}",
        async (long id, UpdataCategoryRequest request, ICategoryHandler handler)
            => 
        {
            request.Id = id;
            return await handler.UpdateAsync(request);
        }) 
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<Response<Category?>>();

app.MapDelete(
        "/v1/categories/{id}",
        async(long id,  ICategoryHandler handler)
            =>
        {
            var request = new DeleteCategoryRequest
            {
                Id = id
            };
            return await handler.DeleteAsync(request);
        }) 
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<Response<Category?>>();


app.Run();


