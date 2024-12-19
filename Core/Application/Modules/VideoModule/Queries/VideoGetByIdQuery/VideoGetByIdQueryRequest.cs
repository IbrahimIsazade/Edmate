using Domain.Entities;
using MediatR;

namespace Application.Modules.VideoModule.Queries.VideoGetByIdQuery
{
    public class VideoGetByIdQueryRequest : IRequest<Video>
    {
        public int Id { get; set; }
    }
}