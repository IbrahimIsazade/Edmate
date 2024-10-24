using Domain.Entities.common;
using MediatR;
using Repositories.common;

namespace Application.Services
{
    public interface IEntityService
    {
        Task<T> AddAsync<T>(IRequest<T> request, IAsyncRepository<T> repository, CancellationToken cancellationToken = new()) where T : class, new();
        Task<T> Edit<T>(IRequest<T> request, int id, IAsyncRepository<T> repository, CancellationToken cancellationToken = new()) where T : class, IEntity;
        Task Delete<T>(IRequest request, int id, IAsyncRepository<T> repository, CancellationToken cancellationToken = new()) where T : class, IEntity;
    }
}
