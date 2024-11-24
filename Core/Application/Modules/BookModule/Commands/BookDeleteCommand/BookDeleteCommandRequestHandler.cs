using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.BookModule.Commands.BookDeleteCommand
{
    internal class BookDeleteCommandRequestHandler(IBookRepository bookRepository, IEntityService entityService) : IRequestHandler<BookDeleteCommandRequest>
    {
        async Task IRequestHandler<BookDeleteCommandRequest>.Handle(BookDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await entityService.Delete(request, request.Id, bookRepository, cancellationToken);
        }
    }
}