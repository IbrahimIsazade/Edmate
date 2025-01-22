using Domain.Entities;
using Domain.Entities.Membership;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.CommentModule.Queries.CommentGetByCourseId
{
    internal class CommentGetByCourseIdRequestHandler(
        ICommentRepository commentRepository,
        IMentorRepository mentorRepository,
        ICourseRepository courseRepository,
        UserManager<CustomUser> userManager) : IRequestHandler<CommentGetByCourseIdRequest, IEnumerable<CommentResponse>>
    {
        async Task<IEnumerable<CommentResponse>> IRequestHandler<CommentGetByCourseIdRequest, IEnumerable<CommentResponse>>.Handle(CommentGetByCourseIdRequest request, CancellationToken cancellationToken)
        {
            //var response = await (from comment in commentRepository.GetAll() where comment.CourseId == request.Id
            //                      //join user in userManager.Users on comment.UserId equals user.Id
            //                     select new CommentResponse
            //                     {
            //                         Content = comment.Content,
            //                         UserName = /*user.Name + " " + user.Surname*/ "User",
            //                         ProfilePath = "profile",
            //                         IsMentor = true,
            //                     }).ToListAsync(cancellationToken);

            var course = await courseRepository.GetAsync(m => m.Id == request.Id);

            var comments = await (from comment in commentRepository.GetAll() where comment.CourseId == request.Id
                           select new Comment
                           {
                               Content = comment.Content,
                               CourseId = comment.CourseId,
                               UserId = comment.UserId,
                           }).ToListAsync(cancellationToken);

            var mentor = await mentorRepository.GetAsync(m => m.Id == course.MentorId);

            var response = new List<CommentResponse>();

            foreach (var comment in comments)
            {
                if (comment.UserId == mentor.IdentityId)
                {
                    var comm = new CommentResponse
                    {
                        Id = comment.Id,
                        Content = comment.Content,
                        ProfilePath = mentor.ProfilePath,
                        UserName = mentor.FirstName + " " + mentor.LastName,
                        IsMentor = true,
                    };

                    response.Add(comm);
                }
            }

            if (response is null)
                throw new NotFoundException("Not found");

            return response;
        }
    }
}
