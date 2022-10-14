using dapper_db.Interfaces;
using dapper_db.Repository;
using dapper_db.Context;
using dapper_db.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IProductsRespository, ProductsRespository>();
builder.Services.AddScoped<IProductsService, ProductsServices>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_policyDevelopment",
        builder =>
        {
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        }
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("_policyDevelopment");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
