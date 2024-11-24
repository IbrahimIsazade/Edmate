using Application.Services;
using MediatR;
using Repositories;

namespace Application.Modules.CommentModule.Commands.CommentDeleteCommand
{
    internal class CommentDeleteCommandRequestHandler(ICommentRepository commentRepository, IEntityService entityService) : IRequestHandler<CommentDeleteCommandRequest>
    {
        async Task IRequestHandler<CommentDeleteCommandRequest>.Handle(CommentDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await entityService.Delete(request, request.Id, commentRepository, cancellationToken);
        }
    }
}