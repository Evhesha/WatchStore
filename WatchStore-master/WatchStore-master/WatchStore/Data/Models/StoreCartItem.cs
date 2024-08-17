using System.ComponentModel;

namespace WatchStore.Data.Models
{
    public class StoreCartItem
    {
        public int Id { get; set; }
        public Watch? watch { get; set; }
        public int price {  get; set; }
        public string? StoreCartId { get; set; }
    }
}
