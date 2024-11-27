using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.GetAllQuery
{
    internal class MentorGetAllQueryRequestHandler(IMentorRepository mentorRepository) : IRequestHandler<MentorGetAllQueryRequest, IEnumerable<Mentor>>
    {
        public async Task<IEnumerable<Mentor>> Handle(MentorGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return mentorRepository.GetAll().ToList();
        }
    }
}