namespace PokemonReviewApp.Models
{
	public class Reviewer
	{
		/// <summary>Reviewer id</summary>
		public int Id { get; set; }
		/// <summary>Reviewer first name</summary>
		public string FirstName { get; set; }
		/// <summary>Reviewer last name</summary>
		public string LastName { get; set; }
		/// <summary>Reviews</summary>
		public ICollection<Review> Reviews { get; set;}
	}
}
