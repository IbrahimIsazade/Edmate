using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.BookModule.Queries.BookGetByIdQuery
{
    internal class BookGetByIdQueryRequestHandler(IBookRepository bookRepository) : IRequestHandler<BookGetByIdQueryRequest, Book>
    {
        public async Task<Book> Handle(BookGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await bookRepository.GetAsync(m => m.Id == request.Id);
        }
    }
}