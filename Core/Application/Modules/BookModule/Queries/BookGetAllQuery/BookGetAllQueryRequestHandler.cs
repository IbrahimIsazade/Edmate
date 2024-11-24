using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.BookModule.Queries.BookGetAllQuery
{
    internal class BookGetAllQueryRequestHandler(IBookRepository bookRepository) : IRequestHandler<BookGetAllQueryRequest, IEnumerable<Book>>
    {
        public async Task<IEnumerable<Book>> Handle(BookGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return bookRepository.GetAll().ToList();
        }
    }
}