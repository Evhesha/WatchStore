using WatchStore.Data.Interfaces;
using WatchStore.Data.Models;

namespace WatchStore.Data.Mocks
{
    public class MockWatches : IWatches
    {
        private readonly IWatchesCategory _category = new MockCategory();

        public IEnumerable<Watch> Watches
        {
            get
            {
                return new List<Watch>
                {
                    new Watch { Name = "Jacob&Co", ShortDescription = "", Description = "",
                        Img = "https://th.bing.com/th/id/R.21059588c5556786ecd8b87c4a374dae?rik=4O3aPAEtJ8%2boaA&pid=ImgRaw&r=0",
                        Price = 20000, IsFavorite = true, Available = true, Category = _category.AllCategories.Last()},
                    new Watch { Name = "Rolex", ShortDescription = "", Description = "",
                        Img = "https://th.bing.com/th/id/OIP.3YM2O26WHqAvY2YL_ARlGAHaHa?rs=1&pid=ImgDetMain",
                        Price = 20000, IsFavorite = true, Available = true, Category = _category.AllCategories.Last()}
                };
            }
        }
        public IEnumerable<Watch> GetFavWatches { get; set; }

        public Watch GetObjectWatch(int id)
        {
            throw new NotImplementedException();
        }
    }
}
