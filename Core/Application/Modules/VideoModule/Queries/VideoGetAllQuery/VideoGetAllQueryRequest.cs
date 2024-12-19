using Domain.Entities;
using MediatR;

namespace Application.Modules.VideoModule.Queries.VideoGetAllQuery
{
    public class VideoGetAllQueryRequest : IRequest<IEnumerable<Video>>
    {
        // properties if they are needed
    }
}