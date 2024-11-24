using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class BookRepository : AsyncRepository<Book>, IBookRepository
	{
		public BookRepository(DbContext db) : base(db) { }
	}

}
