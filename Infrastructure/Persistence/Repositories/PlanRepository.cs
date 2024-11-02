using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class PlanRepository : AsyncRepository<Plan>, IPlanRepository
	{
		public PlanRepository(DbContext db) : base(db) { }
	}

}
