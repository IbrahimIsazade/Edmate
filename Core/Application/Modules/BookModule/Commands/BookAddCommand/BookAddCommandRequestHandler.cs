using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.BookModule.Commands.BookAddCommand
{
    internal class BookAddCommandRequestHandler(IBookRepository bookRepository, IEntityService entityService) : IRequestHandler<BookAddCommandRequest, Book>
    {
        public async Task<Book> Handle(BookAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, bookRepository, cancellationToken);
        }
    }
}