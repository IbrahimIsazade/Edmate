using Domain.Entities;
using MediatR;

namespace Application.Modules.VideoModule.Commands.GetAllQuery
{
    public class VideoGetAllQueryRequest : IRequest<IEnumerable<Award>>
    {
        // properties if they are needed
    }
}