using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sumos.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<SumosDbContext>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SumosDbContext>(options =>
    options.UseAzureSql(builder.Configuration.GetConnectionString("AZURE_CONNECTION_STRING")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapIdentityApi<IdentityUser>();

app.MapControllers();

app.Run();