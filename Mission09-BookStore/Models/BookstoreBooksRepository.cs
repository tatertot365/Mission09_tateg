using System;
using System.Linq;

namespace Mission09_BookStore.Models
{
	// This interface gets all the books form the repo
	public interface BookstoreBooksRepository
	{
		IQueryable<Books> Books { get; }
	}
}

