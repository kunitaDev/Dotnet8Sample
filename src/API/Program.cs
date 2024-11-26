using Application;
using Infastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInjectionApplication();
builder.Services.AddInfastructureServices(builder.Configuration);
builder.Services.AddComponentServiceServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

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

