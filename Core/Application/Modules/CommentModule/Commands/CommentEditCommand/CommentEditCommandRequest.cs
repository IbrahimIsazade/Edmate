using Domain.Entities;
using MediatR;

namespace Application.Modules.CommentModule.Commands.CommentEditCommand
{
    public class CommentEditCommandRequest : IRequest<Comment>
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}