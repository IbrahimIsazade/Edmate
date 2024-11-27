using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.EditCommand
{
    internal class MentorEditCommandRequestHandler(IMentorRepository mentorRepository, ICategoryRepository categoryRepository, IFileService fileService) : IRequestHandler<MentorEditCommandRequest, Mentor>
    {
        public async Task<Mentor> Handle(MentorEditCommandRequest request, CancellationToken cancellationToken)
        {
            if (await categoryRepository.GetAsync(m => m.Id == request.CategoryId) == null)
                throw new NotFoundException("Category not found");

            var mentor = await mentorRepository.GetAsync(m => m.Id == request.Id);
            mentor.FirstName = request.FirstName;
            mentor.LastName = request.LastName;
            mentor.Location = request.Location;
            mentor.Email = request.Email;
            mentor.PhoneNumber = request.PhoneNumber;
            mentor.Bio = request.Bio;
            mentor.CategoryId = request.CategoryId;
            mentor.Followers = request.Followers;
            mentor.Following = request.Following;
            mentor.Likes = request.Likes;
            mentor.IsVerified = false;

            if(request.Profile != null)
                mentor.ProfilePath = await fileService.UploadAsync(request.Profile, cancellationToken);

            if(request.Cover != null)
                mentor.CoverPath = await fileService.UploadAsync(request.Cover, cancellationToken);

            await mentorRepository.AddAsync(mentor, cancellationToken);
            await mentorRepository.SaveAsync(cancellationToken);

            return mentor;
        }
    }
}