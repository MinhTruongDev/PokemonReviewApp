namespace PokemonReviewApp.Models
{
	public class Pokemon
	{
		/// <summary>Pokemon id</summary>
		public int Id { get; set; }
		/// <summary>Pokemon name</summary>
		public string Name { get; set; }
		/// <summary>Pokemon birthdate</summary>
		public DateTime BirthDate { get; set; }
		/// <summary>Reviews</summary>
		public ICollection<Review> Reviews { get; set; }
	}
}
