using BookStore.Domain.CatalogueAggregate;
using BookStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Repository
{
	public class CatalogueRepository : ICatalogueRepository
	{
		private readonly BookStoreDbContext _context;
		public CatalogueRepository(BookStoreDbContext context)
		{
			_context = context;
		}

		public async Task<int> Add(Catalogue entity)
		{
			await _context.Catalogue.AddAsync(entity);
			return 1;
		}

		public async Task<int> Delete(int id)
		{
			var catalogue = await _context.Catalogue.FindAsync(id);
			_context.Catalogue.Remove(catalogue);
			return 1;
		}

		public async Task<Catalogue> Get(int id)
		{
			return await _context.Catalogue.FindAsync(id);
		}

		public async Task<IEnumerable<Catalogue>> GetAll()
		{
			return await _context.Catalogue.ToListAsync();
		}

		public async Task<int> Update(Catalogue entity)
		{
			var catalogue = await _context.Catalogue.FindAsync(entity);
			this._context.Entry(catalogue).CurrentValues.SetValues(entity);
			return 1;
		}
	}
}
