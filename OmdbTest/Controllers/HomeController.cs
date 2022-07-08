using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using OmdbTest.Models;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OmdbTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public static string movieId;
        public static string movieTitle;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        private async Task<RootObject> GetMovieInfo(string searchMovie)
        {
            var client = _httpClientFactory.CreateClient("API Client");

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

        private async Task<RootObject> GetMovieImdbId(string imdbID)
        {
            var client = _httpClientFactory.CreateClient("API Client");

            var result = await client.GetAsync("http://www.omdbapi.com/?i=" + imdbID + "&apikey=729623cd");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RootObject>(content);
            }
            return null;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index(string SearchString)
        {
            if (ModelState.IsValid)
            {
                var model = await GetMovieInfo(SearchString);
                movieId = model.imdbID;
                movieTitle = model.Title;
                return View(model);
            }

            return View("");
        }


        [HttpGet]
        public async Task<IActionResult> Detail(string imdbID)
        {
            var model = await GetMovieImdbId(movieId);
         
            return View(model);
            
        }

        public IActionResult MailSender()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MailSender(Mail mail)
        {
            using(MailMessage message = new MailMessage(mail.FromEmail, mail.To))
            {
                message.Subject = movieTitle;
                message.Body =  $"Hörmətli {mail.Fullname}, sifarişiniz qəbul olundu. Artıq  {movieTitle} filmini istədiyiniz zaman izləyə bilərsiniz. \nBizi seçdiyiniz üçün təşəkkürlər!";
                message.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient()
                {
                    Host = "172.23.0.55",
                    Port = 25,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = "e-manat\\nabi.huseynov",
                        Password = "5663255Emanat!$"
                    }                   
                };
                smtp.Send(message);
            }
           // return View();
            return RedirectToAction("Index");
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
