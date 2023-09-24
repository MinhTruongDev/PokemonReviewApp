using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
	/// <summary>
	/// Category repository interface
	/// </summary>
	public interface ICategoryRepository
	{
		/// <summary>
		/// Get all categories
		/// </summary>
		/// <returns>List of categories</returns>
		ICollection<Category> GetCategories();

		/// <summary>
		/// Get category
		/// </summary>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category</returns>
		Category? GetCategory(int categoryId);

		/// <summary>
		/// Get pokemons by category
		/// </summary>
		/// <param name="categoryId">Category id</param>
		/// <returns>List of pokemons</returns>
		ICollection<Pokemon> GetPokemonByCategory(int categoryId);

		/// <summary>
		/// Is category exist?
		/// </summary>
		/// <param name="categoryId">Category id</param>
		/// <returns>If category exist: TRUE, else: FALSE</returns>
		bool CategoryExists(int categoryId);
	}
}
