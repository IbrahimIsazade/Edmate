using Domain.Entities;
using MediatR;

namespace Application.Modules.CommentModule.Commands
{
    public class CommentAddCommandRequest : IRequest<Comment>
    {
        public string Content { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public int? CommentId { get; set; }
    }
}