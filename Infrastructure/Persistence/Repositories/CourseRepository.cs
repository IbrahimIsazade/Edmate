using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class CourseRepository : AsyncRepository<Course>, ICourseRepository
	{
		public CourseRepository(DbContext db) : base(db) { }
	}

}
