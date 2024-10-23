using Domain.Entities;
using Repositories.common;

namespace Repositories
{
    public interface IMessageRepository : IAsyncRepository<Message> { }
}
