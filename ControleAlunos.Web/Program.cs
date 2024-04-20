using Blazored.Modal;
using Blazored.Modal.Services;
using ControleAlunos.Web;
using ControleAlunos.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredModal();


var baseUrl = "https://localhost:7265";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IModalService, ModalService>();


await builder.Build().RunAsync();
