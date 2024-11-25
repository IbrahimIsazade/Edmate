using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CommentModule.Queries.CommentGetByIdQuery
{
    internal class CommentGetByIdQueryRequestHandler(ICommentRepository commentRepository) : IRequestHandler<CommentGetByIdQueryRequest, Comment>
    {
        public async Task<Comment> Handle(CommentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await commentRepository.GetAsync(m => m.Id == request.Id);
        }
    }
}