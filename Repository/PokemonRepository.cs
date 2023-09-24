using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
	public class PokemonRepository: IPokemonRepository
	{
		/// <summary>Data context</summary>
		private readonly DataContext _context;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dataContext"></param>
		public PokemonRepository(DataContext dataContext)
		{
			_context = dataContext;
		}

		/// <summary>
		/// Get pokemons
		/// </summary>
		/// <returns>List of pokemon</returns>
		public ICollection<Pokemon> GetPokemons()
		{
			return _context.Pokemons.OrderBy(p => p.Id).ToList();
		}

		/// <summary>
		/// Get pokemon
		/// </summary>
		/// <param name="pokemonId">Pokemon id</param>
		/// <returns>Pokemon</returns>
		public Pokemon? GetPokemon(int pokemonId)
		{
			return _context.Pokemons
				.Where(p => p.Id == pokemonId)
					.FirstOrDefault();
		}
		/// <summary>
		/// Get pokemon
		/// </summary>
		/// <param name="pokemonName">Pokemon name</param>
		/// <returns>Pokemon</returns>
		public Pokemon? GetPokemon(string pokemonName)
		{
			return _context.Pokemons
				.Where(p => p.Name == pokemonName)
					.FirstOrDefault();
		}

		/// <summary>
		/// Get pokemon rating
		/// </summary>
		/// <param name="pokemonId">Pokemon id</param>
		/// <returns>Pokemon rating</returns>
		public decimal GetPokemonRating(int pokemonId)
		{
			var review = _context.Reviews.Where(p => p.Pokemon.Id == pokemonId);

			if (review.Count() <= 0)
				return 0;

			return (decimal)review.Sum(r => r.Rating) / review.Count();
		}

		/// <summary>
		/// Is this pokemon exists?
		/// </summary>
		/// <param name="pokemonId">Pokemon id</param>
		/// <returns>If exist this Pokemon: TRUE, esle: FALSE</returns>
		public bool PokemonExists(int pokemonId)
		{
			return _context.Pokemons.Any(p => p.Id == pokemonId);
		}
	}
}
