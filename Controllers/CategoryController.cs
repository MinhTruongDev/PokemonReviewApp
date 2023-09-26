using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers
{
	/// <summary>
	/// Category controller
	/// </summary>
	[Route("/api/[controller]")]
	[ApiController]
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="categoryRepository">Category repository</param>
		/// <param name="mapper">Mapper</param>
		public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		/// <summary>
		/// Get all categories
		/// </summary>
		/// <returns>List of categories</returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
		public IActionResult GetCategories()
		{
			var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(categories);
		}

		/// <summary>
		/// Get category by id
		/// </summary>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category</returns>
		[HttpGet("{categoryId:int}")]
		[ProducesResponseType(200, Type = typeof(CategoryDto))]
		[ProducesResponseType(400)]
		public IActionResult GetCategory(int categoryId)
		{
			if (!_categoryRepository.CategoryExists(categoryId))
				return NotFound();

			var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(category);
		}
	}
}
