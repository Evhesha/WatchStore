﻿namespace WatchStore.Data.Models
{
    public class Category
    {
        public int Id {  get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public List<Watch>? Watches {  get; set; } 
    }
}
