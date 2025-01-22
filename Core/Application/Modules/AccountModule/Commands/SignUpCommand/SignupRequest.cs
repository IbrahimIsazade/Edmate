using MediatR;

namespace Application.Modules.AccountModule.Commands.SignUpCommand
{
    public class SignUpRequest : IRequest
    {
        public string Name { get; set; }
        public string Surename { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsMentor { get; set; }
        public bool SubscribeForNews { get; set; }
    }
}
