using Microsoft.EntityFrameworkCore;
using Code.Services;
using code.DataModels;
using code.Services;

const string connection_to_db = "Host=den-sav-isfku19.postgres.database.azure.com;Database=postgres;Username=denielius_savrukovas;Password=03072018Lab4";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<CharacterContext>(options =>
    options
        .UseNpgsql(connection_to_db)
        .UseSnakeCaseNamingConvention());



builder.Services.AddScoped<CharacterService>();

builder.Services.AddDbContext<PlayerContext>(options =>
    options
        .UseNpgsql(connection_to_db)
        .UseSnakeCaseNamingConvention());


builder.Services.AddScoped<PlayerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
