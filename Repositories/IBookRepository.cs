using Domain.Entities;
using Repositories.common;

namespace Repositories
{

    public interface IBookRepository : IAsyncRepository<Book> { }

}
