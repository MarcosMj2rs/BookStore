using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;
using BookStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Repository
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddRepository(this IServiceCollection services)
		{
			services.AddTransient<IBookRepository, BooksRepository>();
			services.AddTransient<ICatalogueRepository, CatalogueRepository>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();

			services.AddDbContext<BookStoreDbContext>(opt => opt
				.UseSqlServer("Data Source=DESKTOP-FUSO9ER\\SQLEXPRESS;Initial Catalog=DB_LIVRARIA;User ID=livrariaDB; Password=1234"));
			return services;
		}
	}
}
