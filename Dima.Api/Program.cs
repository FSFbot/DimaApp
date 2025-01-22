var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//Request - Requisição  GET, POST, PUT e DELETE 
// Obter, Criar, Atualizar, Deletar
// Get - Não tem corpo; ja os outros normalmente possuem Json como corpo
app.MapGet("/", () => "Hello World!");
app.MapPost("/", () => "Hello World!");
app.MapPut("/", () => "Hello World!");
app.MapDelete("/", () => "Hello World!");

app.Run();
