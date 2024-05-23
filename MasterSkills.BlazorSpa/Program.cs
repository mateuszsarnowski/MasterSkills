using Blazored.LocalStorage;
using MasterSkills.BlazorSpa;
using MasterSkills.BlazorSpa.Contracts;
using MasterSkills.BlazorSpa.Providers;
using MasterSkills.BlazorSpa.Services;
using MasterSkills.BlazorSpa.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorBootstrap();

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7044"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();

builder.Services.AddCascadingAuthenticationState();


await builder.Build().RunAsync();
