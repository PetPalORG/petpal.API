using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetPalBack.Application.Internal.CommandServices;
using PetPalBack.Domain.Repositories;
using PetPalBack.Infrastructure.Persistence.EFC.Repositories;
using PetPalBack.Profiles.Domain.Services;
using PetPalBack.shared.Domain.Repositories;
using PetPalBack.shared.Infrastructure.Interfaces.ASP.Configurations;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Repositories;
using PetPalBack.shared.Interfaces.ASP.Configurations;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add databases connections
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Configura database conect and loggin levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
        {
            if (builder.Environment.IsDevelopment())
            {
                options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            }
            else if (builder.Environment.IsProduction())
            {
                options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            }
        }
    }
);

//Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);


// Add services to the container.

//Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(option =>
{
    option.Conventions.Add(new KebabCaseRouteNamingConvention());
});

//Dependency Injection

//Shares Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

/// News Bounded Context Infection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

//Verify DatabaBase Objects are created

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();

