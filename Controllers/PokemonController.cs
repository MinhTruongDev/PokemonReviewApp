using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
	/// <summary>
	/// Pokemon controller
	/// </summary>
	[Route("/api/[controller]")]
	[ApiController]
	public class PokemonController : Controller
	{
		private readonly IPokemonRepository _pokemonRepository;
		private readonly IMapper _mapper;

		public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
		{
			_pokemonRepository = pokemonRepository;
			_mapper = mapper;
		}

		/// <summary>
		/// Get pokemons
		/// </summary>
		/// <returns>List of pokemon</returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<PokemonDto>))]
		public IActionResult GetPokemons()
		{
			var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemons);
		}

		[HttpGet("by-owner/{ownerId:int}")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<PokemonDto>))]
		[ProducesResponseType(400)]
		public IActionResult GetPokemonByOwner(int ownerId)
		{
			var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemonByOwner(ownerId));

			if (pokemons.Count < 1)
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemons);
		}

		/// <summary>
		/// Get pokemons by category
		/// </summary>
		/// <param name="categoryId">Category id</param>
		/// <returns>List of pokemons</returns>
		[HttpGet("by-category/{categoryId:int}")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<PokemonDto>))]
		[ProducesResponseType(400)]
		public IActionResult GetPokemonByCategory(int categoryId)
		{
			var pokemons = _mapper.Map<List<PokemonDto>>(
				_pokemonRepository.GetPokemonByCategory(categoryId));

			if (pokemons.Count < 1)
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemons);
		}

		/// <summary>
		/// Get pokemon by id
		/// </summary>
		/// <param name="pokemonId">Pokemon id</param>
		/// <returns>Pokemon</returns>
		[HttpGet("{pokemonId:int}")]
		[ProducesResponseType(200, Type = typeof(PokemonDto))]
		[ProducesResponseType(400)]
		public IActionResult GetPokemon(int pokemonId)
		{
			if (!_pokemonRepository.PokemonExists(pokemonId))
				return NotFound();

			var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokemonId));

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemon);
		}

		/// <summary>
		/// Get pokemon by name
		/// </summary>
		/// <param name="pokemonName">Pokemon name</param>
		/// <returns>Pokemon</returns>
		[HttpGet("by-name/{pokemonName}")]
		[ProducesResponseType(200, Type = typeof(PokemonDto))]
		[ProducesResponseType(400)]
		public IActionResult GetPokemon(string pokemonName)
		{
			var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokemonName));
			if (pokemon == null)
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemon);
		}

		/// <summary>
		/// Get pokemon rating
		/// </summary>
		/// <param name="pokemonId">Pokemon id</param>
		/// <returns>Pokemon rating</returns>
		[HttpGet("rating/{pokemonId}")]
		[ProducesResponseType(200, Type = typeof(decimal))]
		[ProducesResponseType(400)]
		public IActionResult GetPokemonRating(int pokemonId)
		{
			if(!_pokemonRepository.PokemonExists(pokemonId))
				return NotFound();

			var pokemonRating = _pokemonRepository.GetPokemonRating(pokemonId);

			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemonRating);
		}
	}
}
