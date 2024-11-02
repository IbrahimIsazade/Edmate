using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class StudentRepository : AsyncRepository<Student>, IStudentRepository
	{
		public StudentRepository(DbContext db) : base(db) { }
	}

}
