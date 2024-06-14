using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var GameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ?? throw new Exception("GamesStoreApiUrl is not Set");
builder.Services.AddHttpClient<GamesClients>(client => client.BaseAddress = new Uri(GameStoreApiUrl));
builder.Services.AddHttpClient<GenresClients>(client => client.BaseAddress = new Uri(GameStoreApiUrl));

// builder.Services.AddSingleton<GamesClients>();
// builder.Services.AddSingleton<GenresClients>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
