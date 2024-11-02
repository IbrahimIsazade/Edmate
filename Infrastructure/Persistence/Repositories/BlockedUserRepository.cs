using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class BlockedUserRepository : AsyncRepository<BlockedUser>, IBlockedUserRepository
	{
		public BlockedUserRepository(DbContext db) : base(db) { }
	}

}
