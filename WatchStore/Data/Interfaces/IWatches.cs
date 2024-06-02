using WatchStore.Data.Models;

namespace WatchStore.Data.Interfaces
{
    public interface IWatches
    {
        IEnumerable<Watch> Watches { get; set; } 
        IEnumerable<Watch> GetFavWatches {  get; set; }
        Watch GetObjectWatch(int id);
    }
}
