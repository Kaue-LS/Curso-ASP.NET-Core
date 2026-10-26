using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new (1, "Street Fighter", "Fighting", 249.99M, new DateOnly(1992, 7, 15)),
    new (2, "Mortal Kombat", "Fighting", 199.99M, new DateOnly(1992, 10, 8)),
    new (3, "Tekken", "Fighting", 299.99M, new DateOnly(1994, 12, 9)),
];

// Rotas
// GET /games
app.MapGet("/games", () =>
{
    return games;
});
// GET /games/{id}
app.MapGet("/games/{id}", (int id) =>
{
    return games.Find(game => game.id == id);
}).WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new(
    games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.id }, game);
});

// PUT /games/1
app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.id == id);

    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

// DELETE /games/1
app.MapDelete("/games/{id}", (int id) =>
{
    games.RemoveAll(game => game.id == id);
    return Results.NoContent();
});

// Iniciar aplicação
app.Run();
// Procura por dotnet new list para ver os templates disponíveis
// Procura pra web/empty
// Apos selecionar coloque dotnet new web/empty -n NomeDoProjeto