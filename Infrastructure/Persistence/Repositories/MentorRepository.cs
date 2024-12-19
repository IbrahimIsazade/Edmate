using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class MentorRepository : AsyncRepository<Mentor>, IMentorRepository
	{
		public MentorRepository(DbContext db) : base(db) { }
	}

}
