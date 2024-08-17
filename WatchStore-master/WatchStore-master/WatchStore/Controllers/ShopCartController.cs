using Microsoft.AspNetCore.Mvc;
using WatchStore.Data.Models;
using WatchStore.Data.Repository;

namespace WatchStore.Controllers
{
    public class ShopCartController
    {
        private readonly WatchesRepository? _watchesRepository;
        private readonly StoreCart? _storeCart;

        public ShopCartController(WatchesRepository watchesRepository, StoreCart storeCart)
        {
            _watchesRepository = watchesRepository;
            _storeCart = storeCart;
        }

        //public ViewResult Index()
        //{
        //
        //}
    }
}
