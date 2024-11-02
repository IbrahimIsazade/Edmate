using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{
    public class MessageRepository : AsyncRepository<Message>, IMessageRepository
    {
        public MessageRepository(DbContext db) : base(db) { }
    }

}
