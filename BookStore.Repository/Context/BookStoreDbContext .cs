using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Context
{
	public class BookStoreDbContext : DbContext
	{
		public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

		public DbSet<Book> Book { get; set; }
		public DbSet<Catalogue> Catalogue { get; set; }
	}
}
