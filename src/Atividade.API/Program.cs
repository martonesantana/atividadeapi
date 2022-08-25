using Atividade.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration["ConexaoSqlite:SqliteConnectionString"];
                    builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(connection)
            );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Atividade.API", Version = "v1" });
        options.DocInclusionPredicate((docName, description) => true);
        options.CustomSchemaIds(type => type.FullName);
    }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.RoutePrefix = "api/doc";
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Atividades API v1");
        }
    );
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
