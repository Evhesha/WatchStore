namespace WatchStore.Data.Models
{
    public class Watch
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Img { get; set; }
        public ushort Price { get; set; }
        public bool IsFavorite { get; set; }
        public int CategoryId { get; set; }
        public bool Available { get; set; }
        public virtual Category? Category { get; set; }
    }
}
