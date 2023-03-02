using System;
using System.Linq;

namespace Mission09_BookStore.Models
{
	public class EFBookstoreBooks : BookstoreBooksRepository
	{
		private BookstoreContext context { get; set; }

		public EFBookstoreBooks(BookstoreContext temp) {
			context = temp;
		}

		public IQueryable<Books> Books => context.Books;
	}
}

