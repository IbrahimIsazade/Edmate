﻿using Application.Extensions;
using Domain.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Domain.Exceptions;
using Application.Services;

namespace Application.Modules.AccountModule.Commands.SignInCommand
{
    class SignInRequestHandler(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, ICryptoService cryptoService) : IRequestHandler<SignInRequest, AuthenticateResponse>
    {
        public async Task<AuthenticateResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            string key = Environment.GetEnvironmentVariable("JWT__KEY")!;
            string issuer = Environment.GetEnvironmentVariable("JWT__ISSUER")!;
            string audience = Environment.GetEnvironmentVariable("JWT__AUDIENCE")!;
            int minutes = Convert.ToInt32(Environment.GetEnvironmentVariable("JWT__EXPIRATIONDURATIONMINUTES"));

            CustomUser? user = request.UserName switch
            {
                _ when request.UserName.IsMail() => await userManager.FindByEmailAsync(request.UserName),
                _ when request.UserName.IsPhone() => await userManager.Users.FirstOrDefaultAsync(m => m.PhoneNumberConfirmed && request.UserName.Equals(m.PhoneNumber)),
                _ => await userManager.FindByNameAsync(request.UserName)
            };

            if (user is null)
                throw new Exception("NameOrPasswordIncorrect");

            var checkPasswordResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (checkPasswordResult.IsLockedOut)
                throw new AccountLockoutException();

            if (!checkPasswordResult.Succeeded)
                throw new UserNameOrPasswordIncorrectException();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer, audience,
            claims: [ new(JwtRegisteredClaimNames.NameId, $"{user.Id}") ],
            expires: DateTime.UtcNow.AddMinutes(minutes),
            signingCredentials: credentials);

            var response = new AuthenticateResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token)
            };

            response.RefreshToken = cryptoService.Sha1Hash($"Edmate_{response.AccessToken}");

            return response;
        }
    }
}
