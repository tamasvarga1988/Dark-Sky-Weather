using AutoMapper;
using System;
using System.Linq;
using Dtos = DarkSkyWeather.Contracts.Dtos;

namespace DarkSkyWeather.Services.Mapping
{
    internal static class MapperConfig
    {
        internal static IMapper DailyWeatherMapper { get; private set; }
        internal static IMapper CurrentWeatherMapper { get; private set; }
        internal static IMapper ForecastResultMapper { get; private set; }

        static MapperConfig()
        {
            // DailyWeatherMapper
            var dailyWeatherMapperConfig = 
                new MapperConfiguration(cfg => cfg.CreateMap<ApiModel.DailyWeather, Dtos.DailyWeather>()
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.Time))));

            DailyWeatherMapper = dailyWeatherMapperConfig.CreateMapper();

            // CurrentWeatherMapper
            var currentWeatherMapperConfig =
                new MapperConfiguration(cfg => cfg.CreateMap<ApiModel.CurrentWeather, Dtos.CurrentWeather>()
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.Time))));

            CurrentWeatherMapper = currentWeatherMapperConfig.CreateMapper();

            // ForecastResultMapper
            var forecastResultMapperConfig =
                new MapperConfiguration(cfg => cfg.CreateMap<ApiModel.ForecastResult, Dtos.Forecast>()
                    .ForMember(dst => dst.Current, opt => opt.MapFrom(src =>
                        CurrentWeatherMapper.Map<Dtos.CurrentWeather>(src.CurrentWeather)))                        
                    .ForMember(dst => dst.DailyForecast, opt => opt.Ignore())
                    .AfterMap((apiModel, dataModel) =>
                    {
                        dataModel.DailyForecast = apiModel.DailyData.Days.Select(d => 
                            DailyWeatherMapper.Map<Dtos.DailyWeather>(d))
                            .ToList();
                    }));

            ForecastResultMapper = forecastResultMapperConfig.CreateMapper();
        }
        
        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        
    }
}
