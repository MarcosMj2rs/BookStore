using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private IUnitOfWork _unitOfWork;

		public BooksController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/<Books>
		[HttpGet]
		public async Task<IEnumerable<Book>> Get()
		{
			return await _unitOfWork.Books.GetAll();
		}

		[HttpGet("Genre")]
		public IEnumerable<Book> GetByGenre([FromQuery] string Genre)
		{
			return _unitOfWork.Books.GetBooksByGenre(Genre);
		}

		// GET api/<Books>/5
		[HttpGet("{id}")]
		public async Task<Book> Get(int id)
		{
			return await _unitOfWork.Books.Get(id);
		}

		// POST api/<Books>
		[HttpPost]
		public IActionResult Post()
		{
			var Catalog = new Catalogue
			{
				CatalogueId = 2,
				Name = "Diversos",
				Description = "Administração e carreiras e assuntos de interesse comuns"

			};

			var book = new Book
			{
				Id = 3,
				Genre = "Administração",
				Author = "Sun Tzu",
				Title = "A arte da guerra: Os treze capítulos completos",
				Price = 17.40M,
				Publish = "Jardim dos Livros",
				CatalogueId = Catalog.CatalogueId
			};

			_unitOfWork.Catalogues.Add(Catalog);
			_unitOfWork.Books.Add(book);
			_unitOfWork.Complete();
			return Ok();
		}
	}
}
