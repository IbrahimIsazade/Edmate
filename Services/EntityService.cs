using Application.Services;
using Domain.Entities.common;
using Domain.Exceptions;
using MediatR;
using Repositories.common;
using Services.Registration;

namespace Services
{
    class EntityService : IEntityService
    {
        public async Task<T> AddAsync<T>(IRequest<T> request, IAsyncRepository<T> repository, CancellationToken cancellationToken = default) where T : class, new()
        {
            var entity = new T();

            MapProperties(request, entity);

            await repository.AddAsync(entity, cancellationToken);
            await repository.SaveAsync(cancellationToken);

            return entity;
        }

        public async Task<T> Edit<T>(IRequest<T> request, int id, IAsyncRepository<T> repository, CancellationToken cancellationToken = default) where T : class, IEntity
        {
            var entity = await repository.GetAsync(m => m.Id == id);

            MapProperties(request, entity);

            repository.Edit(entity);
            await repository.SaveAsync(cancellationToken);

            return entity;
        }

        public async Task Delete<T>(IRequest request, int id, IAsyncRepository<T> repository, CancellationToken cancellationToken = default) where T : class, IEntity
        {
            var entity = await repository.GetAsync(m => m.Id == id);

            if (entity == null)
                throw new NotFoundException("Entity not found");

            repository.Delete(entity);
            await repository.SaveAsync();
        }

        private static void MapProperties(object source, object target)
        {
            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = target.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var targetProperty = targetProperties.FirstOrDefault(p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);

                if (targetProperty != null && targetProperty.CanWrite)
                {
                    var value = sourceProperty.GetValue(source);
                    targetProperty.SetValue(target, value);
                }
            }
        }

    }
}
