using Domain.Entities;
using MediatR;

namespace Application.Modules.CommentModule.Queries.CommentGetByIdQuery
{
    public class CommentGetByIdQueryRequest : IRequest<CommentResponse>
    {
        public int Id { get; set; }
    }
}