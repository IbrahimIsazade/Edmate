using Domain.Entities;
using MediatR;

namespace Application.Modules.CommentModule.Queries.CommentGetByCourseId
{
    public class CommentGetByCourseIdRequest : IRequest<IEnumerable<CommentResponse>>
    {
        public int Id { get; set; }
    }
}
