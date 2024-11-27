using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.MentorModule.Commands.EditCommand
{
    public class MentorEditCommandRequest : IRequest<Mentor>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? Profile { get; set; }
        public IFormFile? Cover { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public int Likes { get; set; }
        public bool IsVerified { get; set; }
    }
}