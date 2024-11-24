using Domain.Entities;
using MediatR;

namespace Application.Modules.BookModule.Commands.BookAddCommand
{
    public class BookAddCommandRequest : IRequest<Book>
    {
        public int Name { get; set; }
    }
}