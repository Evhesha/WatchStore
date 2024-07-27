using System.Data.Entity;

namespace WatchStore.Data.Models
{
    public class StoreCart
    {
        private readonly AppDBContent _content;

        public StoreCart(AppDBContent content)
        {
            _content = content;
        }

        public string? StoreCartId { get; set; }
        public List<StoreCartItem>? Items { get; set; }
        public static StoreCart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);
            return new StoreCart(context) { StoreCartId = shopCartId };
        }

        public void AddToCart(Watch watch, int amount)
        {
            this._content.StoreCartItem.Add(new StoreCartItem
            {
                StoreCartId = StoreCartId,
                watch =  watch,
                price = watch.Price
            });

            _content.SaveChanges();
        }

        public List<StoreCartItem> GetShopItems()
        {
            return _content.StoreCartItem.Where(c => c.StoreCartId == StoreCartId).Include(s => s.watch).ToList();
        }
    }
}
