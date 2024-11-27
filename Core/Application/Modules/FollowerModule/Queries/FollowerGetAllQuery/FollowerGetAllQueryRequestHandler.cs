using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FollowerModule.Commands.GetAllQuery
{
    internal class FollowerGetAllQueryRequestHandler(IFollowerRepository followerRepository) : IRequestHandler<FollowerGetAllQueryRequest, IEnumerable<Follower>>
    {
        public async Task<IEnumerable<Follower>> Handle(FollowerGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return followerRepository.GetAll().ToList();
        }
    }
}