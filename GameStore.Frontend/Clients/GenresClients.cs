using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClients(HttpClient httpClient)
{
    // private readonly Genre[] genres =
    // [
    //     new (){
    //         Id=1,
    //         Name="Fighting"
    //     },
    //     new (){
    //         Id=2,
    //         Name="Role-Playing"
    //     },
    //     new (){
    //         Id=3,
    //         Name="Horror"
    //     },
    //     new (){
    //         Id=4,
    //         Name="Simulation"
    //     },
    //     new (){
    //         Id=5,
    //         Name="Sports"
    //     }
    // ];

    public async Task<Genre[]> GetGenresAsync() => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];

    internal Genre[] GetGenres()
    {
        throw new NotImplementedException();
    }
}
