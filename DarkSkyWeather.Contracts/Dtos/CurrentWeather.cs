﻿namespace DarkSkyWeather.Contracts.Dtos
{
    public class CurrentWeather : WeatherBase
    {
        public double Temperature { get; set; }
        public double ApparentTemperature { get; set; }
        public double UV { get; set; }
    }
}
