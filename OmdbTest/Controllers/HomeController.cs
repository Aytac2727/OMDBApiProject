using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OmdbTest.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace OmdbTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        private async Task<RootObject> GetMovieInfo(string searchMovie)
        {
            var client = _httpClientFactory.CreateClient("API Client");
            //string searchMovie="";
            //https://www.omdbapi.com/?t=star&apikey=729623cd
            //http://www.omdbapi.com/?i=tt3896198&apikey=729623cd

            var result = await client.GetAsync("https://www.omdbapi.com/?t="+ searchMovie +"&apikey=729623cd");

            if (result.IsSuccessStatusCode)
            {               
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RootObject>(content);               
            }
            return null;
        }



        public async Task<IActionResult> Index(string SearchString)
        {
            var model = await GetMovieInfo(SearchString);
           
            return View(model);
            
        }


        public async Task<IActionResult> Detail(string ImdbID)
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
