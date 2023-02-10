using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ProductApi.DataAccess;
using ProductApi.DataAccess.Repository;
using ProductApi.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    option => option.UseNpgsql(builder.Configuration.GetConnectionString("PgDbConnection"))
);

builder.Services.AddCors(options =>
    options.AddPolicy("AllowSpecific", p => p.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()));

builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

var app = builder.Build();


app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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