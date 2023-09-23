namespace PokemonReviewApp.Models
{
	public class PokemonOwner
	{
		/// <summary>Pokemon id</summary>
		public int PokemonId { get; set; }
		/// <summary>Owner id</summary>
		public int OwnerId { get; set; }
		/// <summary>Pokemon</summary>
		public Pokemon Pokemon { get; set; }
		/// <summary>Owner</summary>
		public Owner Owner { get; set; }

	}
}
