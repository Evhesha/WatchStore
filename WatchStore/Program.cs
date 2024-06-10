using System.Data.Entity;
using WatchStore.Data;
using WatchStore.Data.Interfaces;
using WatchStore.Data.Mocks;
using Microsoft.EntityFrameworkCore;
using WatchStore.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
//builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection));

// ��������� ����� � ��� ���������
builder.Services.AddSingleton<IWatches, MockWatches>();
builder.Services.AddSingleton<IWatchesCategory, MockCategory>();
builder.Services.AddMvc();

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
