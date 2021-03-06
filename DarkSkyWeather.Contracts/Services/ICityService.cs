﻿using DarkSkyWeather.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DarkSkyWeather.Contracts.Services
{
    public interface ICityService
    {
        Task<List<City>> GetCities();
    }
}