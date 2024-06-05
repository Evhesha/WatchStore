using Microsoft.AspNetCore.Mvc;
using WatchStore.Data.Interfaces;
using WatchStore.Data.Mocks;

namespace WatchStore.Controllers
{
    public class WatchesController : Controller
    {
        private readonly MockWatches _watches;
        private readonly IWatchesCategory _categories;

        public WatchesController(MockWatches watches, IWatchesCategory categories)
        {
            _watches = watches;
            _categories = categories;
        }

        public ViewResult Watches()
        {
            var watches = _watches.Watches.ToList(); // Преобразование в List<Watch>
            return View(watches);
        }
    }
}
