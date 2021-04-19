using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;
using System;

namespace BookStore.Domain
{
	public interface IUnitOfWork : IDisposable
	{
		IBookRepository Books { get; }
		ICatalogueRepository Catalogues { get; }
		int Complete();
	}
}
