using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WatchStore.Data;
using WatchStore.Data.Models;

namespace WatchStore.Pages
{
    public class WatchesModel : PageModel
    {
        [BindProperty]
        public string Category { get; set; } = "All";

        [BindProperty]
        public string From { get; set; }

        [BindProperty]
        public string To { get; set; }

        public AppDBContent DbContext { get; set; }

        public WatchesModel(AppDBContent dbContext)
        {
            DbContext = dbContext;
        } 

        public void OnGet() { }

        private IHtmlContent DisplayWatchCard(Watch watch)
        {
            var htmlContentBuilder = new HtmlContentBuilder();

            htmlContentBuilder.AppendHtml($@"
            <div class='col-sm-4 mb-4'>
                <div class='card h-100'>
                    <img src='{watch.Img}' class='card-img-top' alt='{watch.Name}'>
                    <div class='card-body'>
                        <h5 class='card-title'>{watch.Name}</h5>
                        <p class='card-text'>{watch.ShortDescription}</p>
                        <p class='card-text'>{watch.Price}$</p>
                        <a href='#' class='btn btn-outline-primary'>More Details</a>
                        <a href='#' class='btn btn-outline-success'>Add to cart</a>
                    </div>
                </div>
            </div>");

            return htmlContentBuilder;
        }

        private bool IsWithinPriceRange(decimal price)
        {
            if (string.IsNullOrEmpty(From) && string.IsNullOrEmpty(To))
            {
                return true;
            }

            decimal fromPrice = string.IsNullOrEmpty(From) ? decimal.MinValue : Convert.ToDecimal(From);
            decimal toPrice = string.IsNullOrEmpty(To) ? decimal.MaxValue : Convert.ToDecimal(To);

            return price >= fromPrice && price <= toPrice;
        }
    

        public IHtmlContent DisplayWatches(List<Watch> watches)
        {
            var htmlContentBuilder = new HtmlContentBuilder();

            foreach (var watch in watches)
            {
                if (IsWithinPriceRange(watch.Price))
                {
                    htmlContentBuilder.AppendHtml(DisplayWatchCard(watch));
                }
            }

            return htmlContentBuilder;
        }

        public IHtmlContent DisplayElectronicWatches(List<Watch> watches)
        {
            var htmlContentBuilder = new HtmlContentBuilder();

            foreach (var watch in watches)
            {
                if (watch.CategoryId == 1 && IsWithinPriceRange(watch.Price))
                {
                    htmlContentBuilder.AppendHtml(DisplayWatchCard(watch));
                }
            }

            return htmlContentBuilder;
        }

        public IHtmlContent DisplayMechanicalWatches(List<Watch> watches)
        {
            var htmlContentBuilder = new HtmlContentBuilder();

            foreach (var watch in watches)
            {
                if (watch.CategoryId == 2 && IsWithinPriceRange(watch.Price))
                {
                    htmlContentBuilder.AppendHtml(DisplayWatchCard(watch));
                }
            }

            return htmlContentBuilder;
        }
    }
}
