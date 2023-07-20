using Casgem_RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapidApi.Controllers
{
    public class CityLocationController : Controller
    {
        public async Task<IActionResult> Index(string  cityname = "London")
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "2d7c2f32c8msh15391ec0d5ae2bep13c8fcjsnf59db3069ad3" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
               var value = JsonConvert.DeserializeObject<List<LocationCityNameViewModel>>(body);
                return View(value);
            }
            return View();
        }
     
    }

}
