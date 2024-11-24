using Domain.Entities;
using MediatR;

namespace Application.Modules.MentorModule.Commands.GetByIdQuery
{
    public class MentorGetByIdQueryRequest : IRequest
    {
        public int Id { get; set; }
    }
}