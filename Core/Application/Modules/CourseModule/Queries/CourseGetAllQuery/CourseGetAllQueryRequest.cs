using Domain.Entities;
using MediatR;

namespace Application.Modules.CourseModule.Commands.GetAllQuery
{
    public class CourseGetAllQueryRequest : IRequest<IEnumerable<Award>>
    {
        // properties if they are needed
    }
}