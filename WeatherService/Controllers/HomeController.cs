using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherService.Models;

namespace WeatherService.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(WeatherVM weatherVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var request = String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=c3023616e1b1e2324a9f56882b12e779", weatherVM.Query);

                    var client = new HttpClient();

                    //var response = await client.GetStringAsync(request);
                    var response = await client.GetAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseMessage = await response.Content.ReadAsStringAsync();
                        extractWeatherDataFromJson(weatherVM, responseMessage);
                    }
                    else
                    {
                        weatherVM.ResponseCode = 404;
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine("Error message: {0}", e.Message);
                }
            }
            


            return View(weatherVM);
        }


        private void extractWeatherDataFromJson(WeatherVM weatherVM, string response)
        {  
            JObject json = JObject.Parse(response);

            weatherVM.ResponseCode = int.Parse(json["cod"].ToString());

            weatherVM.Weather = new WeatherInfo()
            {
                Temp = kelvinToCelsius(float.Parse(json["main"]["temp"].ToString())),
                Pressure = json["main"]["pressure"].ToString(),
                WindSpeed = json["wind"]["speed"].ToString(),
                Humidity = json["main"]["humidity"].ToString(),
                Cloudiness = json["clouds"]["all"].ToString(),
                CityName = json["name"].ToString()
            };

        }

        private string kelvinToCelsius(float temp)
        {
            return String.Format("{0:0.##}",temp-273,15);
        }
    }
}