using DMP_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;

namespace DMP_project.Controllers
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

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync("https://api.apify.com/v2/acts/educational_paper~my-actor-2/runs/last/dataset/items?token=apify_api_Bb17LqMbxE9UCfG5K15aRXuuxeNTnB3KRDxk");

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<List<ExtractedDataModel>>();

                if (apiResponse != null && apiResponse.Count > 0)
                {
                    var model = apiResponse[0];
                    return View(model);
                }
            }

            return View("Error"); 
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}