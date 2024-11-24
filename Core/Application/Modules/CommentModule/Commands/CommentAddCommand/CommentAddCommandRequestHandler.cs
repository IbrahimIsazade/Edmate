using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.CommentModule.Commands
{
    internal class CommentAddCommandRequestHandler(ICommentRepository commentRepository, ICourseRepository courseRepository, IEntityService entityService) : IRequestHandler<CommentAddCommandRequest, Comment>
    {
        public async Task<Comment> Handle(CommentAddCommandRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Content))
                throw new ArgumentNullException(nameof(request));

            if (await courseRepository.GetAsync(m => m.Id == request.CourseId) == null)
                throw new NotFoundException("Course not found");

            return await entityService.AddAsync(request, commentRepository, cancellationToken);
        }
    }
}