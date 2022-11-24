using Microsoft.EntityFrameworkCore;
using VentasAPI.Repositorios;
using VentasAPI.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IClientesService, ClientesService>();
builder.Services.AddTransient<IProductosService, ProductosService>();

var connectionString = builder.Configuration.GetConnectionString("VentasDB");

builder.Services.AddDbContext<VentasDbContext>(optionsAction => optionsAction.UseInMemoryDatabase(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
