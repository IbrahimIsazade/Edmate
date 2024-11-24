using Domain.Entities;
using MediatR;

namespace Application.Modules.CommentModule.Queries.CommentGetByIdQuery
{
    public class CommentGetByIdQueryRequest : IRequest
    {
        public int Id { get; set; }
    }
}