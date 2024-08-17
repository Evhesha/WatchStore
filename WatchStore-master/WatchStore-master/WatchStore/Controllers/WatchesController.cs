using Microsoft.AspNetCore.Mvc;
using WatchStore.Data.Interfaces;
using WatchStore.Data.Models;

namespace WatchStore.Controllers
{
    public class WatchesController : Controller
    {
        private readonly IWatches _watches;
        private readonly IWatchesCategory _categories;

        public WatchesController(IWatches watches, IWatchesCategory categories)
        {
            _watches = watches;
            _categories = categories;
        }

        public ViewResult Watches()
        {
            var watches = _watches.Watches.ToList();
            return View(watches);
        }

        [HttpPost]
        public IActionResult AddWatches()
        {
            return View();
        }

        
    }
}
