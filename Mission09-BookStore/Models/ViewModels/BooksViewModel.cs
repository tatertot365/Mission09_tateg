using System;
using System.Linq;

namespace Mission09_BookStore.Models.ViewModels
{
	// This is for the repo of books, it creates an iqueryable to get the books
	public class BooksViewModel
	{
		public IQueryable<Books> Books { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}

