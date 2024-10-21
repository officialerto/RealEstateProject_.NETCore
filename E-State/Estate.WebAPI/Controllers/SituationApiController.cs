using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Estate.WebAPI.Controllers
{
    [Authorize]
    public class SituationApiController : Controller
    {
        public IActionResult Index()
        {
            var httpClient = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());

            var request = httpClient.GetAsync("https://localhost:7008/api/situation").Result;


            var response = request.Content.ReadAsStringAsync().Result;

            var value = JsonConvert.DeserializeObject<List<Situation>>(response);

            return View(value);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Situation data)
        {
            var httpClient = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());

            var status = JsonConvert.SerializeObject(data);

            StringContent content = new StringContent(status, System.Text.Encoding.UTF8, "application/json");

            var request = httpClient.PostAsync("https://localhost:7008/api/situation", content).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var httpClient = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());

            var request = httpClient.DeleteAsync($"https://localhost:7008/api/situation/{id}").Result;

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {

            var httpClient = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());

            var request = httpClient.GetAsync($"https://localhost:7008/api/situation/{id}").Result;

            var status = JsonConvert.DeserializeObject<Situation>(request.Content.ReadAsStringAsync().Result);

            return View(status);
        }

        [HttpPost]
        public IActionResult Update(Situation data)
        {

            var httpClient = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());

            var status = JsonConvert.SerializeObject(data);

            StringContent content = new StringContent(status, System.Text.Encoding.UTF8, "application/json");

            var request = httpClient.PutAsync("https://localhost:7008/api/situation",content).Result;

            return RedirectToAction("Index"); 
        }

    }
}
