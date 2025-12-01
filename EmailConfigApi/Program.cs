using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using EmailConfigApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Make enums serialize/deserialize as strings (e.g., "IMAP" / "Exchange")
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure EF Core PostgreSQL using connection string from configuration or environment variable
var connStr = builder.Configuration.GetConnectionString("DefaultConnection")
             ?? "Host=postgres;Port=5432;Database=emailconfigs;Username=postgres;Password=postgres";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connStr));

// Allow Angular dev server
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Apply migrations automatically at startup (okay for prototype)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalAngular");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
