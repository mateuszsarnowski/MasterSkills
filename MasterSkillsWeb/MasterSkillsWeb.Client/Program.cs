using MasterSkillsWeb.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var uri = new Uri(builder.Configuration["ApiConfiguration:BaseUrl"] + "api/");
builder.Services.AddWebClientServices(uri);
builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
