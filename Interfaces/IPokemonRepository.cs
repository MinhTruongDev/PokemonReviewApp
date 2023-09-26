using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
	public interface IPokemonRepository
	{
		ICollection<Pokemon> GetPokemons();
		Pokemon? GetPokemon(int pokemonId);
		Pokemon? GetPokemon(string pokemonName);
		decimal GetPokemonRating(int pokemonId);
		ICollection<Pokemon> GetPokemonByOwner(int ownerId);
		ICollection<Pokemon> GetPokemonByCategory(int categoryId);
		bool PokemonExists(int pokemonId);
	}
}
