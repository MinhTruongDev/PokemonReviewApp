using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
	/// <summary>
	/// Category repository
	/// </summary>
	public class CategoryRepository : ICategoryRepository
	{
		private readonly DataContext _context;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="context">Data context</param>
		public CategoryRepository(DataContext context)
		{
			this._context = context;
		}

		/// <summary>
		/// Get all categories
		/// </summary>
		/// <returns>List of categories</returns>
		public ICollection<Category> GetCategories()
		{
			return _context.Categories.ToList();
		}

		/// <summary>
		/// Get category
		/// </summary>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category</returns>
		public Category? GetCategory(int categoryId)
		{
			return _context.Categories
				.Where(c => c.Id == categoryId)
					.FirstOrDefault();
		}

		/// <summary>
		/// Get pokemons by category
		/// </summary>
		/// <param name="categoryId">Category id</param>
		/// <returns>List of pokemons</returns>
		public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
		{
			return _context.PokemonCategories
				.Where(pc => pc.CategoryId == categoryId)
					.Select(pc => pc.Pokemon)
						.ToList();
		}

		/// <summary>
		/// Is category exist?
		/// </summary>
		/// <param name="categoryId">Category id</param>
		/// <returns>If category exist: TRUE, else: FALSE</returns>
		public bool CategoryExists(int categoryId)
		{
			return _context.Categories.Any(c => c.Id == categoryId);
		}
	}
}
