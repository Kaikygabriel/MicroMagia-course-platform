using System.Text.Json.Serialization;
using MicroMagia.Api.Extensions;
using MicroMagia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionString:DefaultConnection"]!;

builder.Services.AddDbContext<AppDbContext>(x=>
    x.UseSqlServer(connectionString,
        b => b.MigrationsAssembly("MicroMagia.Api")));

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


builder.Services.AddOpenApi();
builder.Services.AddDependencyInjection();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();