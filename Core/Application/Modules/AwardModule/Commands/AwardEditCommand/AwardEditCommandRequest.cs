using Domain.Entities;
using MediatR;

namespace Application.Modules.AwardModule.Commands.AwardEditCommand
{
    public class AwardEditCommandRequest : IRequest<Award>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int CourseId { get; set; }
    }
}
