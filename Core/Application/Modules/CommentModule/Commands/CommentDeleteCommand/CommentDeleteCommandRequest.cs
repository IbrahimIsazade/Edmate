using Domain.Entities;
using MediatR;

namespace Application.Modules.CommentModule.Commands.CommentDeleteCommand
{
    public class CommentDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}