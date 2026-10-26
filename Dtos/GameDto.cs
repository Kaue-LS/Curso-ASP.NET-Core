namespace GameStore.Api.Dtos;

// Dtos sao os contratos entre o cliente e o servidor, desde que representam um acordo sobre como 
// as data vão ser transferidas e usadas

// Em C#, o public record serve para criar um tipo de dado que representa um conjunto de informações. 
// Ele é parecido com uma class, mas foi projetado especialmente para objetos cujo valor dos dados 
// é mais importante do que a identidade do objeto.
public record GameDto(
    int id,
    string Name,
    string genre,
    decimal Price,
    DateOnly ReleaseDate
);