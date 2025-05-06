using Country.Infrastructure.Persistence.Extensions;
using Country.Application.Extensions;
using Country.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseApiSwagger();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
