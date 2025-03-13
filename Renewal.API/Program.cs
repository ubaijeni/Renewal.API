using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register repositories
builder.Services.AddScoped<Renewal.DataHub.Repositories.ICategoryRepository, Renewal.DataHub.Repositories.CategoryRepository>();
builder.Services.AddScoped<Renewal.DataHub.Repositories.IPODetailsRepository, Renewal.DataHub.Repositories.PODetailsRepository>();

// Register services
builder.Services.AddScoped<Renewal.Service.Interfaces.ICategoryService, Renewal.Service.BusinessLogic.CategoryService>();
builder.Services.AddScoped<Renewal.Service.Interfaces.IPODetailsService, Renewal.Service.BusinessLogic.PODetailsService>();

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

app.MapControllers(); //avoid https redirect error, lets Swagger work properly

app.Run();
