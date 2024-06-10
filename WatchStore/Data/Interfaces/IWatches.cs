using WatchStore.Data.Models;

namespace WatchStore.Data.Interfaces
{
    public interface IWatches
    {
        IEnumerable<Watch> Watches { get; } 
        IEnumerable<Watch> GetFavWatches {  get; }
        Watch GetObjectWatch(int id);
    }
}
