using AprendendoAPI.API.Persistence.Repositories;
using AprendendoAPI.API.Pesistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("AprendendoAPICs");
builder.Services.AddDbContext<AprendendoAPIContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IJobVacancyRepository, JobVacancyRepository>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>{
    c.SwaggerDoc("v1", new OpenApiInfo{
        Title = "AprendendoAPI.API",
        Version = "v1",
        Contact = new OpenApiContact{
            Name = "Danilo Ceccarelli Sano",
            Email = "daniloceccarelli14@gmail.com"
        }
    });

    var xmlFile = "AprendendoAPI.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
