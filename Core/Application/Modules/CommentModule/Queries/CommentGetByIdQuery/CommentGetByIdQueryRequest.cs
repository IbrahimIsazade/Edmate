using Domain.Entities;
using MediatR;

namespace Application.Modules.CommentModule.Queries.CommentGetByIdQuery
{
    public class CommentGetByIdQueryRequest : IRequest<Comment>
    {
        public int Id { get; set; }
    }
}