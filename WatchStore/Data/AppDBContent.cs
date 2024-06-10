using Microsoft.EntityFrameworkCore;
using WatchStore.Data.Models;

namespace WatchStore.Data
{
    public class AppDBContent : DbContext
    {
        // В файле appsettings.json находится строка подключения приложения к бд
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        // Для уставновления товаров 
        public DbSet<Watch> Watch { get; set; }

        // Для установления категорий
        public DbSet<Category> Category { get; set; }  
    }
}
