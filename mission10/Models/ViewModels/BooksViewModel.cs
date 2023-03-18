using System;
using System.Linq;
using mission10.Models;

namespace mission10.Models.ViewModels
{
	public class BooksViewModel
	{
        public IQueryable<Books> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}

