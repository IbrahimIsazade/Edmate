using Domain.Entities;
using MediatR;

namespace Application.Modules.BookModule.Queries.BookGetByIdQuery
{
    public class BookGetByIdQueryRequest : IRequest<Book>
    {
        public int Id { get; set; }
    }
}