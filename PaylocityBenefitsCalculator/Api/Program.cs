using Api.Persistency;
using Api.Services;
using Api.Services.Calculation;
using Api.Services.Mapping;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DI
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IDependentsService, DependentsService>();
builder.Services.AddScoped<IEmployeesStore, InMemoryEmployeesStore>();
builder.Services.AddScoped<IDependentsStore, InMemoryDependentsStore>();
builder.Services.AddSingleton<IPayrollCalculator, PayrollCalculator>();
builder.Services.AddSingleton<IDateTimeProvider, DefaultDateTimeProvider>();
builder.Services.AddSingleton<BaseBenefitCostStrategy>();
builder.Services.AddSingleton<DependentBenefitCostStrategy>();
builder.Services.AddSingleton<HighEarnerBenefitCostStrategy>();


// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<DependentMappingProfile>();
    cfg.AddProfile<EmployeeMappingProfile>();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employee Benefit Cost Calculation Api",
        Description = "Api to support employee benefit cost calculations"
    });
});

var allowLocalhost = "allow localhost";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowLocalhost,
        policy => { policy.WithOrigins("http://localhost:3000", "http://localhost"); });
});

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowLocalhost);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
