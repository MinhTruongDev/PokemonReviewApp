using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
	public interface ICountryRepository
	{
		ICollection<Country> GetCountries();
		Country? GetCountry(int countryId);
		Country? GetCountryByOwner(int ownerId);
		bool HasCountry(int countryId);
	}
}
