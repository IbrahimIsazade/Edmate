using MediatR;

namespace Application.Modules.AwardModule.Commands.AwardDeleteCommand
{
    public class AwardDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
