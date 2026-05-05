using GestorAlugueis.Data;
using Microsoft.EntityFrameworkCore;
using GestorAlugueis.Repositories;
using GestorAlugueis.Services;
using GestorAlugueis.DTOs;
using GestorAlugueis.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<ImovelRepository>();
builder.Services.AddScoped<ImovelService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
