using Application.Modules.CommentModule.Queries.CommentGetAllQuery;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CommentModule.Queries.CommentGetAllQuery { 
    internal class CommentGetAllQueryRequestHandler(ICommentRepository commentRepository) : IRequestHandler<CommentGetAllQueryRequest, IEnumerable<Comment>>
    {
        public async Task<IEnumerable<Comment>> Handle(CommentGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return commentRepository.GetAll().ToList();
        }
    }
}