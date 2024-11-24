using Domain.Entities;
using MediatR;

namespace Application.Modules.VideoModule.Commands.GetByIdQuery
{
    public class VideoGetByIdQueryRequest : IRequest
    {
        public int Id { get; set; }
    }
}