using Domain.Entities;
using MediatR;

namespace Application.Modules.BookModule.Commands.BookDeleteCommand
{
    public class BookDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}