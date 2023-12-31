﻿namespace PokemonReviewApp.Models
{
	public class Category
	{
		/// <summary>Category id</summary>
		public int Id { get; set; }
		/// <summary>Category name</summary>
		public string Name { get; set; }
		/// <summary>Pokemon categories</summary>
		public ICollection<PokemonCategory> PokemonCategories { get; set; }
	}
}
