using AngleSharp.Html.Parser;


namespace LakewoodScoopScrape.Data
{
    public static class ScoopScraper
    {
        public static List<ScoopItem> Scrape()
        {
            var html = GetScoopHtml();
            return ParseHtml(html);
        }

        private static string GetScoopHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true
            };
            using var client = new HttpClient(handler);

            //client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");

            var url = $"https://thelakewoodscoop.com/";
            var html = client.GetStringAsync(url).Result;
            return html;
        }

        private static List<ScoopItem> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var divs = document.QuerySelectorAll(".td_module_flex");
            var items = new List<ScoopItem>();
            foreach (var div in divs)
            {
                ScoopItem item = new();
                items.Add(item);
                var titleElement = div.QuerySelector(".entry-title.td-module-title");
                if (titleElement != null)
                {
                    item.Title = titleElement.TextContent;
                }

                var image = div.QuerySelector(".entry-thumb");
                if (image != null)
                {
                    if (image != null)
                    {
                        item.Image = image.Attributes["data-img-url"].Value;
                    }
                }

                var blurb = div.QuerySelector(".td-excerpt");
                if (blurb != null)
                {
                    item.Blurb = blurb.TextContent;
                }

                var aTag = div.QuerySelector("a.entry-title");
                if (aTag != null)
                {
                    item.Url = aTag.Attributes["href"].Value;
                }

                var comments = div.QuerySelector(".td-module-comments");
                if (comments != null)
                {
                    item.Comments = comments.TextContent;
                }
                
            }

            return items;
        }
    }
}
