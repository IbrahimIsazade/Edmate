using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class CommentRepository : AsyncRepository<Comment>, ICommentRepository
	{
		public CommentRepository(DbContext db) : base(db) { }
	}

}
