using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.VideoModule.Commands.VideoDeleteCommand
{
    internal class VideoDeleteCommandRequestHandler(IVideoRepository videoRepository) : IRequestHandler<VideoDeleteCommandRequest>
    {
        async Task IRequestHandler<VideoDeleteCommandRequest>.Handle(VideoDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await videoRepository.GetAsync(m => m.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException("Video not found");

            videoRepository.Delete(entity);
            await videoRepository.SaveAsync(cancellationToken);
        }
    }
}