using Microsoft.EntityFrameworkCore;
using SchoolManagement.Context;
using SchoolManagement.Helpers;
using SchoolManagement.Interfaces;
using SchoolManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BootcampDBContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

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
