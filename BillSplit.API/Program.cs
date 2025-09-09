using BillSplit.Infrastructure.GlobalConfiguration;
using BillSplit.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                       ?? builder.Configuration.GetConnectionString("BillSplitConnection") ?? String.Empty;
// Add services to the container.
builder.Services.AddControllers();
builder.Services.ServiceRegistration(connectionString);
builder.Services.AddSwaggerConfig(builder.Configuration);
builder.Services.AddJwtConfig(builder.Configuration);
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigins", policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
    });
}


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowSpecificOrigins");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowSpecificOrigins");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();