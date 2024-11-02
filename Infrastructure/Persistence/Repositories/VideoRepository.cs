using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class VideoRepository : AsyncRepository<Video>, IVideoRepository
	{
		public VideoRepository(DbContext db) : base(db) { }
	}

}
