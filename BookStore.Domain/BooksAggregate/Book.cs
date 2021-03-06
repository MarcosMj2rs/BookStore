namespace BookStore.Domain.BooksAggregate
{
	public class Book
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Author { get; set; }

		public string Publish { get; set; }

		public string Genre { get; set; }

		public decimal  Price { get; set; }

		public int CatalogueId { get; set; }
	}
}
