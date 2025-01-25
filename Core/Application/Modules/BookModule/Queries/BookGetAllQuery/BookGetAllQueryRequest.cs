using Domain.Entities;
using MediatR;

namespace Application.Modules.BookModule.Queries.BookGetAllQuery
{
    public class BookGetAllQueryRequest : IRequest<IEnumerable<BookResponse>>
    {
        // properties if they are needed
    }
}