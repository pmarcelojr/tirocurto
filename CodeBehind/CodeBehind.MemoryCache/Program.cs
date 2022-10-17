using CodeBehind.MemoryCache.Repositories;
using CodeBehind.MemoryCache.Services;
using CodeBehind.MemoryCache.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlite("Data Source=CodeBehind.MemoryCache.db"));
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.Decorate<IProductService, CachedProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
if (await context.Database.EnsureCreatedAsync())
{
    await context.GenerateProduct(1000);
}
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
