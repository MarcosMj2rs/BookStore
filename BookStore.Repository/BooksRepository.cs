using BookStore.Domain.BooksAggregate;
using BookStore.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repository
{
	public class BooksRepository : GenericRepository<Book>, IBookRepository
	{
		public BooksRepository(BookStoreDbContext context) : base(context) { }

		public IEnumerable<Book> GetBooksByGenre(string Genre)
		{
			return _context.Book.Where(x => x.Genre == Genre);
		}
	}
}
