using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;
using BookStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly BookStoreDbContext _context;
		public GenericRepository(BookStoreDbContext context)
		{
			_context = context;
		}

		public async Task<T> Get(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<int> Add(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			return 1;
		}

		public async Task<int> Delete(int id)
		{
			var catalogue = await _context.Catalogue.FindAsync(id);
			_context.Catalogue.Remove(catalogue);
			return 1;
		}

		public async Task<int> Update(T entity)
		{
			var catalogue = await _context.Catalogue.FindAsync(entity);
			this._context.Entry(catalogue).CurrentValues.SetValues(entity);
			return 1;
		}
	}
}
