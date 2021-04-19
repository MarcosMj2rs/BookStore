using BookStore.Domain.BooksAggregate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.CatalogueAggregate
{
	public class Catalogue
	{
		[ForeignKey("RelationProperty")]
		public int CatalogueId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public List<Book> Books { get; set; }
	}
}
