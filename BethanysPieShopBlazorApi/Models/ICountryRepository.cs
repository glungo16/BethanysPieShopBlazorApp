using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopBlazorApi.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
