namespace PokemonReviewApp.Models
{
	public class Owner
	{
		/// <summary>Owner id</summary>
		public int Id { get; set; }
		/// <summary>Owner first name</summary>
		public string FirstName { get; set; }
		/// <summary>Owner last name</summary>
		public string LastName { get; set; }
		/// <summary>Owner gym</summary>
		public string Gym { get; set; }
		/// <summary>Country</summary>
		public Country Country { get; set; }
		/// <summary>Pokemon owners</summary>
		public ICollection<PokemonOwner> PokemonOwners { get; set; }
	}
}
