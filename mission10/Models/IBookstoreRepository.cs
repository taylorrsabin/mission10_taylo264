using System;
using System.Linq;

namespace mission10.Models
{
	public interface IBookstoreRepository
	{
        IQueryable<Books> Books { get; }
    }
}

