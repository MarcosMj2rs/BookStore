using System.Collections.Generic;

namespace BookStore.Domain.BooksAggregate
{
	public interface IBookRepository : IGenericRepository<Book>
	{
		IEnumerable<Book> GetBooksByGenre(string genre);
	}
}
