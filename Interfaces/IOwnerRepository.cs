using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
	public interface IOwnerRepository
	{
		ICollection<Owner> GetOwners();
		Owner? GetOwner(int ownerId);
		ICollection<Owner> GetOwnersByCountry(int countryId);
		bool OwnerExists(int ownerId);
	}
}
