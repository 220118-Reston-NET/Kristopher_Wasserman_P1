global using Serilog;
using LakeJacksonCyclingBL;
using LakeJacksonCyclingDL;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration().WriteTo.File("./logs/user.txt").CreateLogger();
builder.Services.AddScoped<IRepository>(repo => new SqlRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<ILakeJacksonBL, LakeJacksonBL>();

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
