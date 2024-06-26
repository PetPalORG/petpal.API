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


using PetPalBack.Articles.Application.Internal.CommandServices;
using PetPalBack.Articles.Application.Internal.QueryServices;
using PetPalBack.Articles.Domain.Repositories;
using PetPalBack.Articles.Domain.Services;
using PetPalBack.Articles.Infrastructure.Persistence.EFC.Repositories;

using PetPalBack.Shared.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;
using PetPalBack.Shared.Infrastructure.Interfaces.ASP.Configuration;


using PetPalBack.Pet_Care.Application.Internal.CommandServices;
using PetPalBack.Pet_Care.Application.Internal.QueryServices;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

//Add Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
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

builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IPetCommandService, PetCommandService>();
builder.Services.AddScoped<IPetQueryService, PetQueryService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();
builder.Services.AddScoped<IAppointmentQueryService, AppointmentQueryService>();

builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddScoped<ITreatmentCommandService, TreatmentCommandService>();
builder.Services.AddScoped<ITreatmentQueryService, TreatmentQueryService>();

builder.Services.AddScoped<ITreatmentDetailsRepository, TreatmentDetailsRepository>();
builder.Services.AddScoped<ITreatmentDetailsCommandService, TreatmentDetailsCommandService>();
builder.Services.AddScoped<ITreatmentDetailQueryService, TreatmentDetailQueryService>();

builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<IMedicationCommandService, MedicationCommandService>();
builder.Services.AddScoped<IMedicationQueryService, MedicationQueryService>();

builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IDietCommandService, DietCommandService>();
builder.Services.AddScoped<IDietQueryService, DietQueryService>();

// Articles Bounded Context Infection Configuration
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleCommandService, ArticleCommandService>();
builder.Services.AddScoped<IArticleQueryService, ArticleQueryService>();


builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

var app = builder.Build();


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


app.UseAuthorization();
app.MapControllers();
app.Run();
