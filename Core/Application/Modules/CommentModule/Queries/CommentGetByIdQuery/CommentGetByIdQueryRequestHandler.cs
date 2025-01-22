using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.CommentModule.Queries.CommentGetByIdQuery
{
    internal class CommentGetByIdQueryRequestHandler(ICommentRepository commentRepository, IMentorRepository mentorRepository) : IRequestHandler<CommentGetByIdQueryRequest, CommentResponse>
    {
        public async Task<CommentResponse> Handle(CommentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await (from comment in commentRepository.GetAll()
                          join mentor in mentorRepository.GetAll() on comment.UserId equals mentor.Id
                          select new CommentResponse
                          {
                              Content = comment.Content,
                              UserName = mentor.FirstName + " " + mentor.LastName,
                              ProfilePath = mentor.ProfilePath,
                          }).SingleOrDefaultAsync(cancellationToken);

            if (response is null)
                throw new NotFoundException("Not found");

            return response;
        }
    }
}