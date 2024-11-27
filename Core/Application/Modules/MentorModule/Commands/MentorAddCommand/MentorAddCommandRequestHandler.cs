using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.AddCommand
{
    internal class MentorAddCommandRequestHandler(IMentorRepository mentorRepository, ICategoryRepository categoryRepository, IFileService fileService) : IRequestHandler<MentorAddCommandRequest, Mentor>
    {
        public async Task<Mentor> Handle(MentorAddCommandRequest request, CancellationToken cancellationToken)
        {
            if (await categoryRepository.GetAsync(m => m.Id == request.CategoryId) == null)
                throw new NotFoundException("Category not found");

            var mentor = new Mentor()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Location = request.Location,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Bio = request.Bio,
                ProfilePath = await fileService.UploadAsync(request.Profile, cancellationToken),
                CoverPath = await fileService.UploadAsync(request.Cover, cancellationToken),
                CategoryId = request.CategoryId,
                Followers = request.Followers,
                Following = request.Following,
                Likes = request.Likes,
                IsVerified = false,
            };

            await mentorRepository.AddAsync(mentor, cancellationToken);
            await mentorRepository.SaveAsync(cancellationToken);

            return mentor;
        }
    }
}