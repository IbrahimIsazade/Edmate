using Domain.Entities;
using MediatR;

namespace Application.Modules.VideoModule.Queries.VideoGetByCourseIdQuery
{
    public class VideoGetByCourseIdQueryRequest : IRequest<IEnumerable<Video>>
    {
        public int Id { get; set; }
    }
}
