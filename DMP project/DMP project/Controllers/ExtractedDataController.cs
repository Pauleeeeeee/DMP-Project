using Microsoft.AspNetCore.Mvc;
using DMP_project.Interfaces;
using DMP_project.Models;

namespace DMP_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtractedDataController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExtractedDataController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://api.apify.com/v2/acts/educational_paper~my-actor-2/runs/last/dataset/items?token=apify_api_Bb17LqMbxE9UCfG5K15aRXuuxeNTnB3KRDxk");

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<ExtractedDataModel>();
                if (apiResponse != null)
                {
                    return View(apiResponse); 
                }
            }

            return View("Error");
        }
    }
}
