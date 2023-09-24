using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
	public interface IPokemonRepository
	{
		/// <summary>
		/// Get pokemons
		/// </summary>
		/// <returns>List of pokemon</returns>
		ICollection<Pokemon> GetPokemons();

		/// <summary>
		/// Get pokemon
		/// </summary>
		/// <param name="pokemonId">Pokemon id</param>
		/// <returns>Pokemon</returns>
		Pokemon GetPokemon(int pokemonId);
		/// <summary>
		/// Get pokemon
		/// </summary>
		/// <param name="pokemonName">Pokemon name</param>
		/// <returns>Pokemon</returns>
		Pokemon GetPokemon(string pokemonName);

		/// <summary>
		/// Get pokemon rating
		/// </summary>
		/// <param name="pokemonId">Pokemon id</param>
		/// <returns>Pokemon rating</returns>
		decimal GetPokemonRating(int pokemonId);

		/// <summary>
		/// Is this pokemon exists?
		/// </summary>
		/// <param name="pokemonId">Pokemon id</param>
		/// <returns>If exist this Pokemon: TRUE, esle: FALSE</returns>
		bool PokemonExists(int pokemonId);
	}
}
