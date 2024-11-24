using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class AwardRepository : AsyncRepository<Award>, IAwardRepository
	{
		public AwardRepository(DbContext db) : base(db) { }
	}

}
