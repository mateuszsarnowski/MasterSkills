using MasterSkillsWeb.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var uri = new Uri(builder.Configuration["ApiConfiguration:BaseUrl"] + "api/");
builder.Services.AddWebClientServices(uri);

await builder.Build().RunAsync();
