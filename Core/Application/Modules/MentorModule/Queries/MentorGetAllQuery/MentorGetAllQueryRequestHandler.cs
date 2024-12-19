using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.MentorModule.Commands.GetAllQuery
{
    internal class MentorGetAllQueryRequestHandler(IMentorRepository mentorRepository, ICategoryRepository categoryRepository) : IRequestHandler<MentorGetAllQueryRequest, IEnumerable<MentorResponse>>
    {
        public async Task<IEnumerable<MentorResponse>> Handle(MentorGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var query = from mentor in mentorRepository.GetAll()
                        join category in categoryRepository.GetAll() on mentor.CategoryId equals category.Id
                        select new MentorResponse 
                        { 
                            Id = mentor.Id,
                            FirstName = mentor.FirstName,
                            LastName = mentor.LastName,
                            Location = mentor.Location,
                            Email = mentor.Email,
                            PhoneNumber = mentor.PhoneNumber,
                            Bio = mentor.Bio,
                            CategoryName = category.Name,
                            ProfilePath = mentor.ProfilePath,
                            CoverPath = mentor.CoverPath,
                            Followers = mentor.Followers,
                            Following = mentor.Following,
                            Likes = mentor.Likes,
                            IsVerified = mentor.IsVerified,
                        };

            return await query.ToListAsync();
        }
    }
}