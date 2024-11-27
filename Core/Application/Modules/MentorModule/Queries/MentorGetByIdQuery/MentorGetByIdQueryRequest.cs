using Domain.Entities;
using MediatR;

namespace Application.Modules.MentorModule.Commands.GetByIdQuery
{
    public class MentorGetByIdQueryRequest : IRequest<Mentor>
    {
        public int Id { get; set; }
    }
}