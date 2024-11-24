using Domain.Entities;
using MediatR;

namespace Application.Modules.CommentModule.Queries.CommentGetAllQuery
{
    public class CommentGetAllQueryRequest : IRequest<IEnumerable<Comment>>
    {
        // properties if they are needed
    }
}