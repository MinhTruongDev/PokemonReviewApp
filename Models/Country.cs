namespace PokemonReviewApp.Models
{
	public class Country
	{
		/// <summary>Country id</summary>
		public int Id { get; set; }
		/// <summary>Country name</summary>
		public string Name { get; set; }
		/// <summary>Owners</summary>
		public ICollection<Owner> Owners { get; set; }
	}
}
