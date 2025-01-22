using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.StudentModule.Commands.AddCommand
{
    public class StudentAddCommandRequest : IRequest<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IFormFile Profile { get; set; }
        public bool IsStudying { get; set; }
        public int PlanId { get; set; }
    }
}