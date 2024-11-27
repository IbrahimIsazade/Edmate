using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.DeleteCommand
{
    internal class MentorDeleteCommandRequestHandler(IMentorRepository mentorRepository, IEntityService entityService) : IRequestHandler<MentorDeleteCommandRequest>
    {
        public async Task Handle(MentorDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await entityService.Delete(request, request.Id, mentorRepository, cancellationToken);
        }
    }
}