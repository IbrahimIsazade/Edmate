using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class AttachmentRepository : AsyncRepository<Attachment>, IAttachmentRepository
	{
		public AttachmentRepository(DbContext db) : base(db) { }
	}

}
