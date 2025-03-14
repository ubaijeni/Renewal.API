using Microsoft.EntityFrameworkCore;
using Renewal.DataHub;
using Renewal.DataHub.Models.Domain;
using Renewal.DataHub.Models.Repository;
using Renewal.Service.BusinessLogic;
using Renewal.Service.Interfaces;
using Renewal.Service.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SampleDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SampleConnectionString")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddTransient<IClientData, ClientData>();
builder.Services.AddTransient<IRenewalData, RenewalData>();
builder.Services.AddTransient<ITransactionDetailsData, TransactionDetailsData>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IRenewalValueService, RenewalValueService>();
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
