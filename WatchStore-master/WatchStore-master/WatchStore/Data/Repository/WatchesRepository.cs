using System.Data.Entity;
using WatchStore.Data.Interfaces;
using WatchStore.Data.Models;

namespace WatchStore.Data.Repository
{
    public class WatchesRepository : IWatches
    {
        private readonly AppDBContent _content;

        public WatchesRepository(AppDBContent content)
        {
            _content = content;
        }

        public IEnumerable<Watch> Watches => _content.Watch.Include(c => c.Category);

        public IEnumerable<Watch> GetFavWatches => _content.Watch.Where(p => p.IsFavorite).Include(c => c.Category);

        public Watch GetObjectWatch(int id) => _content.Watch.FirstOrDefault(p => p.Id == id);
    }
}
