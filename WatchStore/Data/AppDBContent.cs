﻿using Microsoft.EntityFrameworkCore;
using WatchStore.Data.Models;

namespace WatchStore.Data
{
    public class AppDBContent : DbContext
    {
        // В файле appsettings.json находится строка подключения приложения к бд
        // EF Core и EF были добавлены для работы с БД 
        // EFCore.Tools добавили для работы с миграциями чтобы можно было создать БД на основе наших классов
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        // Для уставновления таблицы товаров 
        public DbSet<Watch> Watch { get; set; }

        // Для установления таблицы категорий
        public DbSet<Category> Category { get; set; }  

        // Для установления таблицы элементов корзины
        public DbSet<StoreCartItem> StoreCartItem { get; set; }
    }
}
