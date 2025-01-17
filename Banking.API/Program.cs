using Banking.API.Data;
using Banking.API.Repository;
using Banking.API.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:5173"
                ) 
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); 
        }
    );
});

// DBContext and Connection to database
builder.Services.AddDbContext<BankingContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("BankingDB")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Inject the proper services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStatementService, StatementService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IAccountService, AccountService>();

// Dependency Inject the proper Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStatementRepository, StatementRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.MapControllers();
app.Run();