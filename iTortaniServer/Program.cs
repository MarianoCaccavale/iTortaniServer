using iTortaniServer.Repository;
using iTortaniServer.Repository.SpeseRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Registro la dependecy injection
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ISpeseRepository, SpeseRepository>();
//Registro il database
builder.Services.AddDbContext<iTortaniServer.Models.OrderContext>(o => o.UseSqlite("Data source = tortani.db"));
builder.Services.AddDbContext<iTortaniServer.Models.Spese.SpeseContext>(o => o.UseSqlite("Data source = tortani.db"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
