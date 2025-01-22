using Domain.Entities;
using MediatR;

namespace Application.Modules.CommentModule.Queries.CommentGetAllQuery
{
    public class CommentGetAllQueryRequest : IRequest<IEnumerable<CommentResponse>>
    {
        // properties if they are needed
    }
}