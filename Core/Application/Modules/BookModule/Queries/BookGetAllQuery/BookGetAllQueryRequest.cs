using Domain.Entities;
using MediatR;

namespace Application.Modules.BookModule.Queries.BookGetAllQuery
{
    public class BookGetAllQueryRequest : IRequest<IEnumerable<Book>>
    {
        // properties if they are needed
    }
}