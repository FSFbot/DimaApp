using Dima.Api.Data;
using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x=> x.CustomSchemaIds(n=> n.FullName));

builder.Services.AddTransient<Handler>();

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
    (Request request, Handler handler) 
        =>handler.Handle(request)) 
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<Response>();


app.Run();

//Request
public class Request
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
//Response
public class Response
{
    public long Id { get; set; }
    public string Title { get; set; } = String.Empty;
}
//Handler

public class Handler(AppDbContext context)
{
    public Response Handle(Request request)
    {
        var category = new Category
        {
            Title = request.Title,
            Description = request.Description
        };
        context.Categories.Add(category);
        context.SaveChanges();
        return new Response
        {
            Id= 4,
            Title = request.Title
        };
    }
}