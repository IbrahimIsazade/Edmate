using Domain.Entities;
using MediatR;

namespace Application.Modules.StudentModule.Commands.GetByIdQuery
{
    public class StudentGetByIdQueryRequest : IRequest
    {
        public int Id { get; set; }
    }
}