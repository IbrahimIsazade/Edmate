using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.CommentModule.Queries.CommentGetAllQuery
{
    internal class CommentGetAllQueryRequestHandler(
        ICommentRepository commentRepository,
        IMentorRepository mentorRepository) : IRequestHandler<CommentGetAllQueryRequest, IEnumerable<CommentResponse>>
    {
        public async Task<IEnumerable<CommentResponse>> Handle(CommentGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return await(from comment in commentRepository.GetAll()
                         join mentor in mentorRepository.GetAll() on comment.UserId equals mentor.Id
                         select new CommentResponse
                         {
                             Content = comment.Content,
                             UserName = mentor.FirstName + " " + mentor.LastName,
                             ProfilePath = mentor.ProfilePath,
                         }).ToListAsync(cancellationToken);


            //var response = from comment in commentRepository.GetAll()
            //               join mentor in mentorRepository.GetAll() on comment.UserId equals mentor.Id
            //               select new CommentResponse
            //               {
            //                   CourseId = comment.CourseId,
            //                   Content = comment.Content,
            //                   UserId = mentor.Id,
            //                   UserName = mentor.FirstName + " " + mentor.LastName,
            //                   ProfilePath = mentor.ProfilePath,
            //               };
        }
    }
}