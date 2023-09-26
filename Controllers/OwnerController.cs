using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
	/// <summary>
	/// Owner controller
	/// </summary>
	[Route("/api/[controller]")]
	[ApiController]
	public class OwnerController : Controller
	{
		private readonly IOwnerRepository _ownerRepository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="ownerRepository">Owner repository</param>
		/// <param name="mapper">Mapper</param>
		public OwnerController(
			IOwnerRepository ownerRepository,
			IMapper mapper)
		{
			_ownerRepository = ownerRepository;
			_mapper = mapper;
		}

		/// <summary>
		/// Get owners
		/// </summary>
		/// <returns>List of owners</returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<OwnerDto>))]
		public IActionResult GetOwners()
		{
			var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(owners);
		}

		[HttpGet("by-country/{countryId:int}")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<OwnerDto>))]
		[ProducesResponseType(400)]
		public IActionResult GetOwnersByCountry(int countryId)
		{
			var owners = _mapper.Map<List<OwnerDto>>(
				_ownerRepository.GetOwnersByCountry(countryId));
			if (owners.Count < 1)
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(owners);
		}

		/// <summary>
		/// Get owner by id
		/// </summary>
		/// <param name="ownerId">Owner id</param>
		/// <returns>Owner</returns>
		[HttpGet("{ownerId:int}")]
		[ProducesResponseType(200, Type = typeof(OwnerDto))]
		[ProducesResponseType(400)]
		public IActionResult GetOwner(int ownerId)
		{
			if (!_ownerRepository.OwnerExists(ownerId))
				return NotFound();
			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerId));

			return Ok(owner);
		}
	}
}
