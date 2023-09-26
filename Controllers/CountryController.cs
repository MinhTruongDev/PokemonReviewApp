using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
	[Route("/api/[controller]")]
	[ApiController]
	public class CountryController:Controller
	{
		private readonly ICountryRepository _countryRepository;
		private readonly IMapper _mapper;

		public CountryController(ICountryRepository countryRepository, IMapper mapper)
		{
			_countryRepository = countryRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
		public IActionResult GetCountries()
		{
			var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(countries);
		}

		[HttpGet("{countryId:int}")]
		[ProducesResponseType(200, Type = typeof(CountryDto))]
		[ProducesResponseType(400)]
		public IActionResult GetCountry(int countryId)
		{
			if (!_countryRepository.HasCountry(countryId))
				return NotFound();

			var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(country);
		}

		[HttpGet("by-owner/{ownerId:int}")]
		[ProducesResponseType(200, Type = typeof(CountryDto))]
		[ProducesResponseType(400)]
		public IActionResult GetCountryByOwner(int ownerId)
		{
			var country = _mapper.Map<CountryDto>(
				_countryRepository.GetCountryByOwner(ownerId));

			if(country == null)
				return NotFound();

			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(country);
		}
	}
}
