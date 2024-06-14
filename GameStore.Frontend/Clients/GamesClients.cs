using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClients(HttpClient httpClient)
{
    //     private readonly List<GameSummary> games =
    //     [
    //     new() {
    // Id=1,
    // Name="Street Fighter II",
    // Genre="Fighting",
    // Price=19.798M,
    // ReleaseDate=new DateOnly(1992,5,12)
    // },
    // new() {
    // Id=2,
    // Name="Final Fantasy III",
    // Genre="Role-Playing",
    // Price=85.798M,
    // ReleaseDate=new DateOnly(2010,6,23)
    // },
    // new() {
    // Id=3,
    // Name="The Walking Dead",
    // Genre="Horror",
    // Price=65.454M,
    // ReleaseDate=new DateOnly(2011,3,15)
    // },
    // new() {
    // Id=4,
    // Name="F1-Formula",
    // Genre="Simulation",
    // Price=98.654M,
    // ReleaseDate=new DateOnly(2011,3,15)
    // },
    // new() {
    // Id=5,
    // Name="FIFA 2023",
    // Genre="Sports",
    // Price=67.54M,
    // ReleaseDate=new DateOnly(2011,3,15)
    // },
    // ];

    // private readonly Genre[] genres = new GenresClients(httpClient).GetGenres();

    public async Task<GameSummary[]> GetGamesAsync()
    {
        return await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
    }

    public async Task AddGameAsync(GameDetails game)
    => await httpClient.PostAsJsonAsync("games", game);
    // {
    //     Genre genre = GetGenreById(game.GenreId);

    //     var gameSummary = new GameSummary
    //     {
    //         Id = games.Count + 1,
    //         Name = game.Name,
    //         Genre = genre.Name,
    //         Price = game.Price,
    //         ReleaseDate = game.ReleaseDate
    //     };

    //     games.Add(gameSummary);
    // }

    public async Task<GameDetails> GetGameAsync(int id)
    => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Could not find game!");
    // {
    //     GameSummary game = GetGameSummaryById(id);

    //     var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

    //     return new GameDetails
    //     {
    //         Id = game.Id,
    //         Name = game.Name,
    //         GenreId = genre.Id.ToString(),
    //         Price = game.Price,
    //         ReleaseDate = game.ReleaseDate
    //     };
    // }

    public async Task UpdateGameAsync(GameDetails updatedGame)
    => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
    // {
    //     var genre = GetGenreById(updatedGame.GenreId);
    //     GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

    //     existingGame.Name = updatedGame.Name;
    //     existingGame.Genre = genre.Name;
    //     existingGame.Price = updatedGame.Price;
    //     existingGame.ReleaseDate = updatedGame.ReleaseDate;
    // }

    public async Task DeleteGameAsync(int id)
    => await httpClient.DeleteAsync($"games/{id}");
    // {
    //     var game = GetGameSummaryById(id);
    //     games.Remove(game);
    // }

    // private GameSummary GetGameSummaryById(int id)
    // {
    //     var game = games.Find(game => game.Id == id);
    //     ArgumentNullException.ThrowIfNull(game);
    //     return game;
    // }

    // private Genre GetGenreById(string? id)
    // {
    //     ArgumentException.ThrowIfNullOrWhiteSpace(id);
    //     return genres.Single(genre => genre.Id == int.Parse(id));

    // }

}
