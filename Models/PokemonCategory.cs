namespace PokemonReviewApp.Models
{
	public class PokemonCategory
	{
		/// <summary>Pokemon id</summary>
		public int PokemonId { get; set; }
		/// <summary>Category id</summary>
		public int CategoryId { get; set; }
		/// <summary>Pokemon</summary>
		public Pokemon Pokemon { get; set; }
		/// <summary>Category</summary>
		public Category Category { get; set; }
	}
}
