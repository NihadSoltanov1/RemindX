using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RemindX.Domain.Entities;
using RemindX.UI.Models;
using System.Text;
using Telegram.Bot.Types;

namespace RemindX.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("http://localhost:5055/api/Remind\r\n");
           var jsonString = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<RemindUI>>(jsonString);

            return View(values);
        }

        [HttpGet]
        public IActionResult AddRemind()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRemind(RemindUI model)
        {
            var jsonRemind = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonRemind, Encoding.UTF8, "application/json");
            var responseMesaj = await _httpClient.PostAsync("http://localhost:5055/api/Remind\r\n",content);
            if (responseMesaj.IsSuccessStatusCode) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRemind(int id)
        {
            var response = await _httpClient.GetAsync("http://localhost:5055/api/Remind/" + id);
            if (response.IsSuccessStatusCode)
            {

            
            var jsonString = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<RemindUI>>(jsonString);

            return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRemind(RemindUI model)
        {
            var jsonRemind = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonRemind, Encoding.UTF8, "application/json");
            var responseMesaj = await _httpClient.PutAsync("http://localhost:5055/api/Remind\r\n", content);
            if (responseMesaj.IsSuccessStatusCode) return RedirectToAction("Index");
            return View(model);
        }


        public async Task<IActionResult> DeleteRemind(int id)
        {
            var response = await _httpClient.DeleteAsync("http://localhost:5055/api/Remind/" + id);
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");

            return RedirectToAction("Index");
        }
    }
}
