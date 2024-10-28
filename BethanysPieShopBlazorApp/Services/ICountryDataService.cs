using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopBlazorApp.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
