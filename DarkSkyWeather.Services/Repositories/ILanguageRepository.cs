using DarkSkyWeather.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services.Repositories
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetLanguages();
    }
}
