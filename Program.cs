using Entity_framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareaContext>(p => p.UseInMemoryDatabase("TareasDb"));
builder.Services.AddSqlServer<TareaContext>(builder.Configuration.GetConnectionString("CnTareas"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/tareas", async ([FromServices] TareaContext db) => {
    db.Database.EnsureCreated();
    return Results.Ok("base de datos " +db.Database.ProviderName + " funcionando.");       
});

app.Run();
