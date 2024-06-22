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
                        <a href='#' class='btn btn-primary'>Подробнее</a>
                    </div>
                </div>
            </div>");

            return htmlContentBuilder;
        }

        public IHtmlContent DisplayWatches(List<Watch> watches)
        {
            var htmlContentBuilder = new HtmlContentBuilder();

            foreach (var watch in watches)
            {
                htmlContentBuilder.AppendHtml(DisplayWatchCard(watch));
            }

            return htmlContentBuilder;
        }

        public IHtmlContent DisplayElectronicWatches(List<Watch> watches)
        {
            var htmlContentBuilder = new HtmlContentBuilder();

            foreach (var watch in watches)
            {
                if (watch.CategoryId == 1)
                    htmlContentBuilder.AppendHtml(DisplayWatchCard(watch));
            }

            return htmlContentBuilder;
        }

        public IHtmlContent DisplayMechanicalWatches(List<Watch> watches)
        {
            var htmlContentBuilder = new HtmlContentBuilder();

            foreach (var watch in watches)
            {
                if (watch.CategoryId == 2)
                    htmlContentBuilder.AppendHtml(DisplayWatchCard(watch));
            }

            return htmlContentBuilder;
        }
    }
}
