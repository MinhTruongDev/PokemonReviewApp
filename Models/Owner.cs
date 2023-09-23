namespace PokemonReviewApp.Models
{
	public class Owner
	{
		/// <summary>Owner id</summary>
		public int Id { get; set; }
		/// <summary>Owner name</summary>
		public string Name { get; set; }
		/// <summary>Owner gym</summary>
		public string Gym { get; set; }
		/// <summary>Country</summary>
		public Country Country { get; set; }
	}
}
