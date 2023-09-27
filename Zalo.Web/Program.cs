
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Zalo.Web;
using Zalo.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiUrl"] ?? "") });

builder.Services.AddHttpClient("Zalo.API", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiUrl"] ?? "");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<TempDataService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ManageService>();
builder.Services.AddScoped<MessageService>();


// Ant Design
builder.Services.AddAntDesign();

await builder.Build().RunAsync();
