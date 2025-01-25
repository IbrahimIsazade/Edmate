using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.BookModule.Queries.BookGetAllQuery
{
    internal class BookGetAllQueryRequestHandler(
        IBookRepository bookRepository, 
        IMentorRepository mentorRepository, 
        ICategoryRepository categoryRepository,
        IAproximateTimeService aproximateTimeService) : IRequestHandler<BookGetAllQueryRequest, IEnumerable<BookResponse>>
        
    {
        public async Task<IEnumerable<BookResponse>> Handle(BookGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await (from books in bookRepository.GetAll()
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
                           PublisherName = mentors.FirstName +" "+ mentors.LastName,
                           PubllisherProfilePath = mentors.ProfilePath,
                           ThumbnailPath  = books.ThumbnailPath,
                           PdfPath = books.PdfPath,
                           AproximateReading = books.AproximateReading,
                       }).ToListAsync();

            return data;
        }
    }
}