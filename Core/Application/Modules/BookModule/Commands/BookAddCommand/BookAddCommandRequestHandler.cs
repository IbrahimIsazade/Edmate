using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.BookModule.Commands.BookAddCommand
{
    internal class BookAddCommandRequestHandler(
        IBookRepository bookRepository,
        IMentorRepository mentorRepository,
        ICategoryRepository categoryRepository,
        IFileService fileService,
        IAproximateTimeService aproximateReadingTimeService) : IRequestHandler<BookAddCommandRequest, Book>
    {
        public async Task<Book> Handle(BookAddCommandRequest request, CancellationToken cancellationToken)
        {
            if(await categoryRepository.GetAsync(m => m.Id == request.CategoryId) == null)
                throw new NotFoundException("Category not found");

            if(await mentorRepository.GetAsync(m => m.Id == request.PublisherId) == null)
                throw new NotFoundException("Mentor/Publisher not found");

            var book = new Book()
            {
                Title = !String.IsNullOrWhiteSpace(request.Title) ? request.Title : throw new ArgumentNullException(),
                Description = !String.IsNullOrWhiteSpace(request.Description) ? request.Description : throw new ArgumentNullException(),
                CategoryId = request.CategoryId,
                PublisherId = request.PublisherId,
                ThumbnailPath = await fileService.UploadAsync(request.Thumbnail, cancellationToken),
                PdfPath = await fileService.UploadAsync(request.Pdf, cancellationToken),
                AproximateReading = await aproximateReadingTimeService.GetApproximateReadingTimeAsync(request.Pdf),
            };

            await bookRepository.AddAsync(book, cancellationToken);
            await bookRepository.SaveAsync(cancellationToken);

            return book;
        }
    }
}