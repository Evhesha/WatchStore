using WatchStore.Data;
using WatchStore.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using WatchStore.Data.Repository;
using WatchStore.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// ��������� dbsettings.json � ������������
builder.Configuration.AddJsonFile("dbsettings.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddRazorPages();

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<AppDBContent>(options => options.
        UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� ����� � ��� ���������
builder.Services.AddTransient<IWatches, WatchesRepository>();
builder.Services.AddTransient<IWatchesCategory, CategoryRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => StoreCart.GetCart(sp));
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();