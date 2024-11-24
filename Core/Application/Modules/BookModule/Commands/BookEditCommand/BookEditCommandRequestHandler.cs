using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.BookModule.Commands.BookEditCommand
{
    internal class BookEditCommandRequestHandler(IBookRepository bookRepository, IFileService fileService) : IRequestHandler<BookEditCommandRequest, Book>
    {
        public async Task<Book> Handle(BookEditCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await bookRepository.GetAsync(m => m.Id == request.Id);

            if (entity == null)
                throw new NotFoundException("Book not found");

            if (request.Thumbnail != null)
            {
                entity.ThumbnailPath = fileService.UploadAsync(request.Thumbnail).ToString()!;
            }

            if (request.Pdf != null)
            {
                entity.PdfPath = fileService.UploadAsync(request.Pdf).ToString()!;
            }

            entity.Title = request.Title;
            entity.Description = request.Description;

            return entity;
        }
    }
}