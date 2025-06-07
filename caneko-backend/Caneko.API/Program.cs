using Caneko.API.Registry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
RepositoryDependencyInjectionConfig.ConfigureServices(builder.Services);
ServiceDependencyInjectionConfig.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x =>
    {
        x.WithOrigins("http://localhost:4200")
            .WithHeaders()
            .WithMethods();
    }
);

app.UseAuthorization();

app.MapControllers();

app.Run();
