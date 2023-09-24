using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
	/// <summary>
	/// Owner repository
	/// </summary>
	public class OwnerRepository: IOwnerRepository
	{
		private readonly DataContext _context;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="context"></param>
		public OwnerRepository(DataContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get owners
		/// </summary>
		/// <returns>List of owners</returns>
		public ICollection<Owner> GetOwners()
		{
			return _context.Owners.ToList();
		}

		/// <summary>
		/// Get owner by id
		/// </summary>
		/// <param name="ownerId">Owner id</param>
		/// <returns>Owner</returns>
		public Owner? GetOwner(int ownerId)
		{
			return _context.Owners
				.Where(o => o.Id == ownerId)
					.FirstOrDefault();
		}

		/// <summary>
		/// Get pokemon by owner
		/// </summary>
		/// <param name="ownerId">Onwer id</param>
		/// <returns>List of pokemons</returns>
		public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
		{
			return _context.PokemonOwners
				.Where(po => po.OwnerId == ownerId)
					.Select(po => po.Pokemon)
						.ToList();
		}

		/// <summary>
		/// Is owner exist?
		/// </summary>
		/// <param name="ownerId">Owner id</param>
		/// <returns>If owner exist: TRUE, else: FALSE</returns>
		public bool OwnerExists(int ownerId)
		{
			return _context.Owners.Any(o => o.Id == ownerId);
		}
	}
}
