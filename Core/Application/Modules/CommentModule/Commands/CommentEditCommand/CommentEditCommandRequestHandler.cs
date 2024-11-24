using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CommentModule.Commands.CommentEditCommand
{
    internal class CommentEditCommandRequestHandler(ICommentRepository commentRepository, IEntityService entityService) : IRequestHandler<CommentEditCommandRequest, Comment>
    {
        public async Task<Comment> Handle(CommentEditCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.Edit(request, request.Id, commentRepository, cancellationToken);
        }
    }
}