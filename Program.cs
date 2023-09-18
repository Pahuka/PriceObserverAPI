using Microsoft.EntityFrameworkCore;
using PriceObserverAPI.DAL;
using PriceObserverAPI.DAL.Interfaces;
using PriceObserverAPI.DAL.Repository;
using PriceObserverAPI.Services.EmailService;
using PriceObserverAPI.Services.Interfaces;
using PriceObserverAPI.Services.ObserverService;
using PriceObserverAPI.Services.UpdatePriceService;
using PriceObserverAPI.Services.UrlService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();
var connetion = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connetion));
builder.Services.AddTransient<IObserverRepository, ObserverRepository>();
builder.Services.AddTransient<IObserverService, ObserverService>();
builder.Services.AddTransient<IUrlParseService, UrlParseService>();
builder.Services.AddTransient<IUpdatePriceService, UpdatePriceService>();
builder.Services.AddTransient<IEmailService, EmailService>();

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