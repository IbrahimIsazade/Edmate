using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.BookModule.Queries.BookGetByIdQuery
{
    internal class BookGetByIdQueryRequestHandler(
        IBookRepository bookRepository, 
        IMentorRepository mentorRepository,
        ICategoryRepository categoryRepository) : IRequestHandler<BookGetByIdQueryRequest, BookResponse>
    {
        public async Task<BookResponse> Handle(BookGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await (from books in bookRepository.GetAll() where books.Id == request.Id
                              join categories in categoryRepository.GetAll() on books.CategoryId equals categories.Id
                              join mentors in mentorRepository.GetAll() on books.PublisherId equals mentors.Id
                              select new BookResponse
                              {
                                  Id = books.Id,
                                  Title = books.Title,
                                  Description = books.Description,
                                  CategoryId = books.CategoryId,
                                  CategoryName = categories.Name,
                                  PublisherId = books.PublisherId,
                                  PublisherName = mentors.FirstName + " " + mentors.LastName,
                                  PubllisherProfilePath = mentors.ProfilePath,
                                  ThumbnailPath = books.ThumbnailPath,
                                  PdfPath = books.PdfPath,
                                  AproximateReading = books.AproximateReading,
                              }).SingleOrDefaultAsync();

            return data!;
        }
    }
}