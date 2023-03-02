using System;
namespace Mission09_BookStore.Models.ViewModels
{
	// The PageInfo class contains all the information about the page the user is on including how many pages there should be
	public class PageInfo
	{
		public int TotalNumBooks { get; set; }
		public int BooksPerPage { get; set; }
		public int CurrentPage { get; set; }

		// Figure out how many pages we need
		public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}

