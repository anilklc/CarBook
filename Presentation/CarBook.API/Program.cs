using CarBook.Application;
using CarBook.Domain.Entities;
using CarBook.Persistence;
using CarBook.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<AppUser>(opt =>
{
	opt.Password.RequiredLength = 3;
	opt.Password.RequireNonAlphanumeric = false;
	opt.Password.RequireDigit = false;
	opt.Password.RequireLowercase = false;
	opt.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<CarBookDbContext>();
//builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<CarBookDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGroup("/User").MapIdentityApi<AppUser>();

app.MapControllers();

app.Run();
