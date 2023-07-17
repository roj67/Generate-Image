using Generate_Image.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Generate_Image.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
        [HttpPost]
        public async Task<IActionResult> GenerateImage([FromBody] RequiredImage obj)
        {
            string imglink = string.Empty;
            var response = new ResponseModel();
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "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");
                var Message = await client.PostAsync("https://api.openai.com/v1/images/generations", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                if (Message.IsSuccessStatusCode)
                {
                    var content = await Message.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<ResponseModel>(content);
                    imglink = response.data[0].url.ToString();
                }
            }
            return Json(response);
        }
    }
}