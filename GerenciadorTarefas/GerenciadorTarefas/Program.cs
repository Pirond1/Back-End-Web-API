using Infraestrutura.Data;
using Infraestrutura.Repositorio;
using Interface.Repositorio;
using Interface.Service;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Mapping;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextoGerenciador>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddAutoMapper(p => p.AddProfile<MappingProfile>());

builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<ITipoTarefaRepositorio, TipoTarefaRepositorio>();
builder.Services.AddScoped<ITipoTarefaService, TipoTarefaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
