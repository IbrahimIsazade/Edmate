using Domain.Entities;
using Repositories.common;

namespace Repositories
{

    public interface ICommentRepository : IAsyncRepository<Comment> { }

}
