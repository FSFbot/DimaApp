var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//Request - Requisição  GET, POST, PUT e DELETE 
// Obter, Criar, Atualizar, Deletar
// Get - Não tem corpo; ja os outros normalmente possuem Json como corpo
app.MapPost(
    "/v1/transactions",
    (Request request, Handler handler) 
        =>handler.Handle(request)) 
    .WithName("Transaction: Create")
    .WithSummary("Cria uma nova transação")
    .Produces<Response>();


app.Run();

//Request
public class Request
{
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public int Type { get; set; }
    public string UserId { get; set; } = string.Empty;
}
//Response
public class Response
{
    public long Id { get; set; }
    public string Title { get; set; } = String.Empty;
}
//Handler

public class Handler
{
    public Response Handle(Request request)
    {
        return new Response
        {
            Id= 4,
            Title = request.Title
        };
    }
}