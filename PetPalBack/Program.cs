using Microsoft.EntityFrameworkCore;
using PetPalBack.IAM.Application.Internal.CommandServices;
using PetPalBack.IAM.Application.Internal.OutboundServices;
using PetPalBack.IAM.Application.Internal.QueryServices;
using PetPalBack.IAM.Domain.Repositories;
using PetPalBack.IAM.Domain.Services;
using PetPalBack.IAM.Infrastructure.Hashing.BCrypt.Services;
using PetPalBack.IAM.Infrastructure.Persistence.EFC.Repositories;
using PetPalBack.IAM.Infrastructure.Tokens.JWT.Configuration;
using PetPalBack.IAM.Infrastructure.Tokens.JWT.Services;
using PetPalBack.IAM.Interfaces.ACL.Services;
using PetPalBack.IAM.Interfaces.ACL;
using PetPalBack.shared.Domain.Repositories;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Repositories;
using PetPalBack.shared.Interfaces.ASP.Configurations;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

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

builder.Services.AddRouting(options => options.LowercaseUrls = true);


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

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
