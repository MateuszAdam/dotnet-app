using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ILocationsRepository, LocationsRepository>();

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



// do refaktoru:
// 
// autofac do rejstracji zale¿noœci
// testy jednostkowe i dodany projekt do testów 
// Action Filters do dodania do walidacji 
// dodanie interfejsow do klas Locations/Teams repository
