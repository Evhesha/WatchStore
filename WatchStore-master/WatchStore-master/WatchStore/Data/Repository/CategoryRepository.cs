using WatchStore.Data.Interfaces;
using WatchStore.Data.Models;

namespace WatchStore.Data.Repository
{
    public class CategoryRepository : IWatchesCategory
    {
        private readonly AppDBContent _content;

        public CategoryRepository(AppDBContent content)
        {
            _content = content;
        }

        public IEnumerable<Category> AllCategories => _content.Category;
    }
}
