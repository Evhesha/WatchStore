using WatchStore.Data.Interfaces;
using WatchStore.Data.Models;

namespace WatchStore.Data.Mocks
{
    public class MockCategory : IWatchesCategory
    {
        public IEnumerable<Category> AllCategories {
            get
            {
                return new List<Category> { 
                    new Category {CategoryName = "Электронные часы", Description = "Часы с пользовательским функционалом"},
                    new Category {CategoryName = "Механические часы", Description = "Для маминых стиляг"}
                };
            }
            set => throw new NotImplementedException(); 
        }
    }
}
