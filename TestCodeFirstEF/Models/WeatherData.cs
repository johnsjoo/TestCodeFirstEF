using System;
using System.Collections.Generic;
using System.Text;

namespace TestCodeFirstEF.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public decimal Temp { get; set; }
        public int Humidity { get; set; }
        public string Location { get; set; }

    }
}
