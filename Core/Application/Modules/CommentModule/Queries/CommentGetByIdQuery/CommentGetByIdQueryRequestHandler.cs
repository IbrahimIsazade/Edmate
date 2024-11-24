using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CommentModule.Queries.CommentGetByIdQuery
{
    internal class CommentGetByIdQueryRequestHandler(ICommentRepository commentRepository, IEntityService entityService) : IRequestHandler<CommentGetByIdQueryRequest>
    {
        public Task Handle(CommentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            
        }
    }
}