using MediatR;
using Microsoft.EntityFrameworkCore;
using PetPalBack.PetRegister.Application.Internal.CommandServices;
using PetPalBack.PetRegister.Application.Internal.QueryServices;
using PetPalBack.PetRegister.Domain.Repositories;
using PetPalBack.PetRegister.Domain.Services;
using PetPalBack.PetRegister.Infraestructure.Repositories;
using PetPalBack.shared.Domain.Repositories;
using PetPalBack.Domain.Repositories;
using PetPalBack.Infrastructure.Persistence.EFC.Repositories;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Repositories;
using PetPalBack.Shared.Infrastructure.Interfaces.ASP.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

//Add Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IPetCommandService, PetCommandService>();
builder.Services.AddScoped<IPetQueryService, PetQueryService>();
//Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(option =>
{
    option.Conventions.Add(new KebabCaseRouteNamingConvention());
});


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
