﻿using BookStore.Domain;
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

		[HttpGet("{Genre}")]
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
			var book = new Book
			{
				Id = 1,
				Genre = "Technology",
				Author = "Charles Petzold",
				Title = "Programming Windows 5th Edition",
				Price = 30,
				Publish = "Microsoft Press"
			};

			var Catalog = new Catalogue
			{
				CatalogueId = 1,
				Name = "Programming Books",
				Description = "Books on Software development"
			};

			_unitOfWork.Books.Add(book);
			_unitOfWork.Catalogues.Add(Catalog);
			_unitOfWork.Complete();
			return Ok();
		}
	}
}
