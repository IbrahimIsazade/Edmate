using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.GetByIdQuery
{
    internal class MentorGetByIdQueryRequestHandler(IMentorRepository mentorRepository) : IRequestHandler<MentorGetByIdQueryRequest, Mentor>
    {
        public async Task<Mentor> Handle(MentorGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await mentorRepository.GetAsync(m => m.Id == request.Id);
        }
    }
}