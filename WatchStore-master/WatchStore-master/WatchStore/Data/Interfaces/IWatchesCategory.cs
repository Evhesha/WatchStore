using WatchStore.Data.Models;

namespace WatchStore.Data.Interfaces
{
    // Интерфейс предназначенный для вытявания из Category.cs моделей
    public interface IWatchesCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
