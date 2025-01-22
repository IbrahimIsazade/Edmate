using Application.Extensions;
using Application.Services;
using Domain.Entities;
using Domain.Entities.Membership;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repositories;

namespace Application.Modules.AccountModule.Commands.SignUpCommand
{
    class SignUpRequestHandler(UserManager<CustomUser> userManager,
        ICryptoService cryptoService,
        IEmailService emailService,
        IMentorRepository mentorRepository,
        IStudentRepository studentRepository,
        IHttpContextAccessor ctx) : IRequestHandler<SignUpRequest>
    {
        public async Task Handle(SignUpRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Signing Up API...");

            if (string.IsNullOrWhiteSpace(request.UserName))
                request.UserName = $"{request.Name}.{request.Surename}".ToLower();


            var user = await userManager.FindByEmailAsync(request.Email);
            if (user is not null)
                throw new BadRequestException("BADREG", new Dictionary<string, IEnumerable<string>>
                {
                    ["Email"] = ["Email is already exists"]
                });

            user = await userManager.FindByNameAsync(request.UserName);
            if (user is not null)
                throw new BadRequestException("BADREG", new Dictionary<string, IEnumerable<string>>
                {
                    ["UserName"] = ["UserName is already exists"]
                });

            user = new CustomUser
            {
                Name = request.Name,
                Surname = request.Name,
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = false,
                IsSubscriber = request.SubscribeForNews
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors
                    .GroupBy(m => m.Code)
                    .ToDictionary(m => m.Key, m => m.Select(m => m.Description).AsEnumerable());

                throw new BadRequestException("BADREG", errors);
            }

            Console.WriteLine("User added...");

            if (result.Succeeded)
            {
                CustomUser? currentUser = await userManager.FindByNameAsync(request.UserName);

                if (currentUser is null)
                    throw new BadRequestException("BADREG", new Dictionary<string, IEnumerable<string>>
                    {
                        ["UserName"] = ["UserName does not exists"]
                    });

                if (request.IsMentor)
                {
                    Console.WriteLine("Is mentor...");

                    var mentor = new Mentor
                    {
                        IdentityId = currentUser.Id,
                        FirstName = request.Name,
                        LastName = request.Surename,
                        Location = "Not provided",
                        Email = request.Email,
                        PhoneNumber = "Not provided",
                        CoverPath = "",
                        ProfilePath = "",
                        Bio = "Not provided",
                        CategoryId = 4, // CHANGE THIS PART !!!
                        IsVerified = false,
                    };

                    await mentorRepository.AddAsync(mentor, cancellationToken);
                    await mentorRepository.SaveAsync(cancellationToken);
                }
                else
                {
                    //var student = new Student
                    //{
                    //    Id = currentUser.Id,
                    //    FirstName = request.Name,
                    //    LastName = request.Surename,              <-----------  IN DEVELOPMENT
                    //    Email = request.Email
                    //};

                    //await studentRepository.AddAsync(student, cancellationToken);
                    //await studentRepository.SaveAsync(cancellationToken);
                }

            }

            Console.WriteLine("Finishing Up...");

            string confirmationUrl = $"{ctx.GetHost()}/approve-account?token={cryptoService.Encrypt($"{user.Id}-{user.Email}-{DateTime.UtcNow.AddMinutes(20):yyyy.MM.dd HH:mm:ss}", true)}";

            string content = "Confirm you email please"; // File.ReadAllText(Path.Combine("wwwroot", "email-templates", "email-confirmation-ticket.html"));

            content = string.Format(content, $"{request.Name} {request.Surename}", confirmationUrl);

            await emailService.SendEmail(request.Email, "Email confirm", content);

        }
    }
}
