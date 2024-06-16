using Microsoft.AspNetCore.Identity;
using WatchStore.Data.Models;

namespace WatchStore.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(content => content.Value));
            }

            if (!content.Watch.Any())
            {
                content.AddRange(
                    new Watch
                    {
                        Name = "Jacob&Co",
                        ShortDescription = "",
                        Description = "",
                        Img = "https://th.bing.com/th/id/R.21059588c5556786ecd8b87c4a374dae?rik=4O3aPAEtJ8%2boaA&pid=ImgRaw&r=0",
                        Price = 20000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Механические часы"]
                    },
                    new Watch
                    {
                        Name = "Rolex",
                        ShortDescription = "",
                        Description = "",
                        Img = "https://th.bing.com/th/id/OIP.3YM2O26WHqAvY2YL_ARlGAHaHa?rs=1&pid=ImgDetMain",
                        Price = 20000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Механические часы"]
                    }); ;
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> _category;

        public static Dictionary<string, Category> Categories {
            get
            {
                if ( _category == null )
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Электронные часы", Description = "Часы с пользовательским функционалом"},
                        new Category {CategoryName = "Механические часы", Description = "Для маминых стиляг"}
                    };

                    _category = new Dictionary<string, Category>();

                    foreach (Category el in list)
                    {
                        _category.Add(el.CategoryName, el);
                    }
                }

                return _category;
            }
        }

    }
}
