using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.BookModule.Commands.BookEditCommand
{
    public class BookEditCommandRequest : IRequest<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

    }
}