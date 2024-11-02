using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class FollowerRepository : AsyncRepository<Follower>, IFollowerRepository
	{
		public FollowerRepository(DbContext db) : base(db) { }
	}

}
