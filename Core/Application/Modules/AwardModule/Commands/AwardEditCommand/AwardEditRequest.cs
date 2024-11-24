using Domain.Entities;
using MediatR;

namespace Application.Modules.AwardModule.Commands.AwardEditCommand
{
    public class AwardEditRequest : IRequest<Award>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int CourseId { get; set; }
    }
}
