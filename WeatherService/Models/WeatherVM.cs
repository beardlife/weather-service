using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherService.Models
{
    public class WeatherVM
    {
        public int ResponseCode { get; set; }
        [Required(ErrorMessage="To pole nie może być puste")]
        [MaxLength(25,ErrorMessage="Maksymalna długość zapytania: 25 znaków")]
        public String Query { get; set; }
        public WeatherInfo Weather { get; set; }
    }
}