using AutoMapper;
using System;
using Dtos = DarkSkyWeather.Contracts.Dtos;

namespace DarkSkyWeather.Services.Mapping
{
    public static class MapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // DailyWeatherMapper
                cfg.CreateMap<ApiModel.DailyWeather, Dtos.DailyWeather>()
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.Time)));

                // CurrentWeatherMapper
                cfg.CreateMap<ApiModel.CurrentWeather, Dtos.CurrentWeather>()
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.Time)));

                // ForecastResultMapper
                cfg.CreateMap<ApiModel.ForecastResult, Dtos.Forecast>()
                    .ForMember(dst => dst.Current, opt => opt.MapFrom(src => src.CurrentWeather))
                    .ForMember(dst => dst.DailyForecast, opt => opt.MapFrom(src => src.DailyData.Days));
            });

            return config.CreateMapper();
        }
        
        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        
    }
}
