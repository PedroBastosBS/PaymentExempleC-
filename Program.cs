using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentService.Application.UseCases;
using PaymentService.Domain.Factories;
using PaymentService.Domain.Interfaces;
using PaymentService.Infrastructure.Persistence;
using PaymentService.Infrastructure.Repositories;
using PaymentService.Domain.Strategies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICreatePlanUseCase, CreatePlanUseCase>();
builder.Services.AddScoped<IGetAllPlansUseCase, GetAllPlansUseCase>();
builder.Services.AddScoped<IUserRegistrationUseCase, UserRegistrationUseCase>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPlanFactory, PlanFactory>();
builder.Services.AddScoped<IUserFactory, UserFactory>();

builder.Services.AddTransient<TicketStrategy>();
builder.Services.AddTransient<PixStrategy>();
builder.Services.AddTransient<CreditCardStrategy>();

builder.Services.AddScoped<IPaymentStrategyFactory, PaymentStrategyFactory>();
builder.Services.AddScoped<IStrategyPayment, CreditCardStrategy>();
builder.Services.AddScoped<IStrategyPayment, PixStrategy>();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Payment Service API",
        Version = "v1",
        Description = "API responsável pela gestão de planos de pagamento. Permite criar, listar e gerenciar planos disponíveis.",
        Contact = new OpenApiContact
        {
            Name = "Pedro Guilherme Bastos",
            Email = "pedrobastos750@gmail.com",
            Url = new Uri("https://github.com/PedroBastosBS/PaymentExempleC-")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<PaymentDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentService API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.Run();
