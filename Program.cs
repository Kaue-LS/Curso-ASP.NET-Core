var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Rotas
app.MapGet("/", () => "Hello World!");

// Iniciar aplicação
app.Run();
// Procura por dotnet new list para ver os templates disponíveis
// Procura pra web/empty
// Apos selecionar coloque dotnet new web/empty -n NomeDoProjeto