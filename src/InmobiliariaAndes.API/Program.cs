using InmobiliariaAndes.API.Utils;
using InmobiliariaAndes.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
var environment  = builder.Environment.EnvironmentName; 

if(environment == "Local")
{
    var contentRootPath = builder.Environment.ContentRootPath;
    var srcPath = Path.Combine(contentRootPath, "..\\..\\");
    var envPath = Path.Combine(srcPath, "local.env");    
    DotEnv.Load(envPath);
}

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Application Services
builder.Services.AddApplicationServices(builder.Configuration); 

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
