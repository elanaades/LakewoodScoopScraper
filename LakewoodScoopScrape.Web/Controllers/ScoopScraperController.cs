using LakewoodScoopScrape.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LakewoodScoopScrape.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoopScraperController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<ScoopItem> Scrape()
        {
            return ScoopScraper.Scrape(); 
        }
    }
}
