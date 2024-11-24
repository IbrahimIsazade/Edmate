using MediatR;

namespace Application.Modules.AwardModule.Commands.AwardDeleteCommand
{
    public class AwardDeleteRequest : IRequest
    {
        public int Id { get; set; }
    }
}
