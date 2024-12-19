using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.BookModule.Commands.BookAddCommand
{
    public class BookAddCommandRequest : IRequest<Book>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public IFormFile Thumbnail { get; set; }
        public IFormFile Pdf { get; set; }
    }
}