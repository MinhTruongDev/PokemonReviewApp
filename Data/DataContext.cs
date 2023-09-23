using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data
{
	public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		/// <summary>
		/// On creating model
		/// </summary>
		/// <param name="modelBuilder">Model builder</param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PokemonCategory>()
				.HasKey(pc => new { pc.PokemonId, pc.CategoryId });
			modelBuilder.Entity<PokemonCategory>()
				.HasOne(p => p.Pokemon)
				.WithMany(pc => pc.PokemonCategories)
				.HasForeignKey(p => p.PokemonId);
			modelBuilder.Entity<PokemonCategory>()
				.HasOne(c => c.Category)
				.WithMany(pc => pc.PokemonCategories)
				.HasForeignKey(c => c.CategoryId);

			modelBuilder.Entity<PokemonOwner>()
				.HasKey(po => new { po.PokemonId, po.OwnerId});
			modelBuilder.Entity<PokemonOwner>()
				.HasOne(p => p.Pokemon)
				.WithMany(pc => pc.PokemonOwners)
				.HasForeignKey(p => p.PokemonId);
			modelBuilder.Entity<PokemonOwner>()
				.HasOne(o => o.Owner)
				.WithMany(pc => pc.PokemonOwners)
				.HasForeignKey(o => o.OwnerId);
		}

		/// <summary>Pokemon table</summary>
		public DbSet<Pokemon> Pokemons { get; set; }
		/// <summary>Owner table</summary>
		public DbSet<Owner> Owners { get; set; }
		/// <summary>Category table</summary>
		public DbSet<Category> Categories { get; set; }
		/// <summary>Country table</summary>
		public DbSet<Country> Countries { get; set; }
		/// <summary>Review table</summary>
		public DbSet<Review> Reviews { get; set; }
		/// <summary>Reviewer table</summary>
		public DbSet<Reviewer> Reviewers { get; set; }
		/// <summary>Pokemon owner join table</summary>
		public DbSet<PokemonOwner> PokemonOwners { get; set; }
		/// <summary>Pokemon category join table</summary>
		public DbSet<PokemonCategory> PokemonCategories { get; set; }
	}
}
