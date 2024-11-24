using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class FeatureRepository : AsyncRepository<Feature>, IFeatureRepository
	{
		public FeatureRepository(DbContext db) : base(db) { }
	}

}
