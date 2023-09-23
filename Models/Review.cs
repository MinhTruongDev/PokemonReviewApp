namespace PokemonReviewApp.Models
{
	public class Review
	{
		/// <summary>Review id</summary>
		public int Id { get; set; }
		/// <summary>Title</summary>
		public string Title { get; set; }
		/// <summary>Text</summary>
		public string Text { get; set; }
		/// <summary>Review rating</summary>
		public int Rating { get; set; }
		/// <summary>Reviewer</summary>
		public Reviewer Reviewer { get; set; }
		/// <summary>Pokemon</summary>
		public Pokemon Pokemon { get; set; }

	}
}
