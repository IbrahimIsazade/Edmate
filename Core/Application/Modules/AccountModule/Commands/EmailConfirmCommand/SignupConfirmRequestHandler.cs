using MediatR;
using Services.common;

namespace Application.Modules.AccountModule.Commands.EmailConfirmCommand
{
    public class SignupConfirmRequestHandler(ICryptoService cryptoService) : IRequestHandler<SignupConfirmRequest>
    {
        public async Task Handle(SignupConfirmRequest request, CancellationToken cancellationToken)
        {
            var response = cryptoService.Decrypt(request.Token);
            Console.WriteLine(response);
        }
    }
}
