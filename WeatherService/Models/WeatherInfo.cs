using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherService.Models
{
    public class WeatherInfo
    {
        [Display(Name = "Nazwa miasta:  ")]
        public string CityName { get; set; }
        [Display(Name="Temperatura")]
        public string Temp { get; set; }
        [Display(Name = "Ciśnienie")]
        public string Pressure { get; set; }
        [Display(Name = "Wilgotność")]
        public string Humidity { get; set; }
        [Display(Name = "Prędkość wiatru")]
        public string WindSpeed { get; set; }
        [Display(Name = "Zachmurzenie")]
        public string Cloudiness { get; set; }
       

    }
}