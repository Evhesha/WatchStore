using WatchStore.Data;
using WatchStore.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using WatchStore.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Добавляем dbsettings.json в конфигурацию
builder.Configuration.AddJsonFile("dbsettings.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddRazorPages();

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AppDBContent>(options => options.
        UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Связываем класс и его интерфейс
builder.Services.AddTransient<IWatches, WatchesRepository>();
builder.Services.AddTransient<IWatchesCategory, CategoryRepository>();

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

app.MapRazorPages();

app.Run();