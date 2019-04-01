using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using DataModel = DarkSkyWeather.Contracts.DataModel;

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
                new MapperConfiguration(cfg => cfg.CreateMap<ApiModel.DailyWeather, DataModel.DailyWeather>()
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.Time)))
                    .ForMember(dst => dst.ApparentTemperatureMaxTime, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.ApparentTemperatureMaxTime)))
                    .ForMember(dst => dst.ApparentTemperatureMinTime, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.ApparentTemperatureMinTime)))
                    .ForMember(dst => dst.TemperatureMaxTime, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.TemperatureMaxTime)))
                    .ForMember(dst => dst.TemperatureMinTime, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.TemperatureMinTime)))
                    .ForMember(dst => dst.UVTime, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.UVTime))));

            DailyWeatherMapper = dailyWeatherMapperConfig.CreateMapper();

            // CurrentWeatherMapper
            var currentWeatherMapperConfig =
                new MapperConfiguration(cfg => cfg.CreateMap<ApiModel.CurrentWeather, DataModel.CurrentWeather>()
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => UnixTimeStampToDateTime(src.Time))));

            CurrentWeatherMapper = currentWeatherMapperConfig.CreateMapper();

            // ForecastResultMapper
            var forecastResultMapperConfig =
                new MapperConfiguration(cfg => cfg.CreateMap<ApiModel.ForecastResult, DataModel.Forecast>()
                    .ForMember(dst => dst.Current, opt => opt.MapFrom(src =>
                        CurrentWeatherMapper.Map<DataModel.CurrentWeather>(src.CurrentWeather)))                        
                    .ForMember(dst => dst.DailyForecast, opt => opt.Ignore())
                    .AfterMap((apiModel, dataModel) =>
                    {
                        dataModel.DailyForecast = apiModel.DailyData.Days.Select(d => 
                            DailyWeatherMapper.Map<DataModel.DailyWeather>(d))
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
