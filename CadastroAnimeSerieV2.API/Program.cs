using CadastroAnimeSerieV2.Dados.Banco;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CadastroAnimeSerieV2Context>((options) => {
    options
            .UseSqlServer(builder.Configuration["ConnectionStrings:CadastroAnimeSerieV2DB"])
            .UseLazyLoadingProxies();
});

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "https://localhost:7089",
            builder.Configuration["FrontendUrl"] ?? "https://localhost:7015"])
            .AllowAnyMethod()
            .SetIsOriginAllowed(pol => true)
            .AllowAnyHeader()
            .AllowCredentials()));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("wasm");

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.Run();
