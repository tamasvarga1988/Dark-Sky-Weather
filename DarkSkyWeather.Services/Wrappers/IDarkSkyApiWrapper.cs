using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Services.ApiModel;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services.Wrappers
{
    public interface IDarkSkyApiWrapper
    {
        Task<ForecastResult> GetForecast(ForecastRequest request);
    }
}
