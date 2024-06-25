using Microsoft.EntityFrameworkCore;

using PetPalBack.Articles.Application.Internal.CommandServices;
using PetPalBack.Articles.Application.Internal.QueryServices;
using PetPalBack.Articles.Domain.Repositories;
using PetPalBack.Articles.Domain.Services;
using PetPalBack.Articles.Infrastructure.Persistence.EFC.Repositories;
using PetPalBack.Shared.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistance.EFC.Configurations;
using PetPalBack.Shared.Infrastructure.Persistance.EFC.Repositories;
using PetPalBack.Shared.Infrastructure.Interfaces.ASP.Configurations;

using PetPalBack.Pet_Care.Application.Internal.CommandServices;
using PetPalBack.Pet_Care.Application.Internal.QueryServices;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Infraestructure.Repositories;
using PetPalBack.Shared.Interfaces.ASP.Configurations;
using PetPalBack.Shared.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistance.EPC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistance.EPC.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

//Add Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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

//Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(option =>
{
    option.Conventions.Add(new KebabCaseRouteNamingConvention());
});

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
