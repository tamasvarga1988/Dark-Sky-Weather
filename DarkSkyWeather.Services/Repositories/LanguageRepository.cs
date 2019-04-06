using System.Collections.Generic;
using System.Threading.Tasks;
using DarkSkyWeather.Contracts.Dtos;

namespace DarkSkyWeather.Services.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private List<Language> languages;

        public Task<List<Language>> GetLanguages()
        {
            if (languages == null)
            {
                InitializeLanguages();
            }

            return Task.FromResult(languages);
        }

        private void InitializeLanguages()
        {
            languages = new List<Language>
            {
                new Language{ Code = "en", LanguageCountryCode = "en-US", Name = "English", Icon = "us" },
                new Language{ Code = "hu", LanguageCountryCode = "hu-HU", Name = "Magyar", Icon = "hu" }
            };
        }
    }
}
