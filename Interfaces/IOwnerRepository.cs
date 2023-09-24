using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
	public interface IOwnerRepository
	{
		/// <summary>
		/// Get owners
		/// </summary>
		/// <returns>List of owners</returns>
		ICollection<Owner> GetOwners();

		/// <summary>
		/// Get owner by id
		/// </summary>
		/// <param name="ownerId">Owner id</param>
		/// <returns>Owner</returns>
		Owner? GetOwner(int ownerId);

		/// <summary>
		/// Get pokemon by owner
		/// </summary>
		/// <param name="ownerId">Onwer id</param>
		/// <returns>List of pokemons</returns>
		ICollection<Pokemon> GetPokemonByOwner(int ownerId);

		/// <summary>
		/// Is owner exist?
		/// </summary>
		/// <param name="ownerId">Owner id</param>
		/// <returns>If owner exist: TRUE, else: FALSE</returns>
		bool OwnerExists(int ownerId);
	}
}
