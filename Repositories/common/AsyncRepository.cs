﻿using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories.common
{
    public class AsyncRepository<T>(DbContext db) : IAsyncRepository<T>
        where T : class
    {
        public async Task AddAsync(T entry, CancellationToken cancellationToken = default)
        {
            await db.Set<T>().AddAsync(entry, cancellationToken);
        }

        public void Delete(T entry)
        {
            db.Entry(entry).State = EntityState.Deleted;
        }

        public void Edit(T entry)
        {
            db.Entry(entry).State = EntityState.Modified;
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>().AsQueryable();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? expression = null, CancellationToken cancellationToken = default)
        {
            var query = db.Set<T>().AsQueryable();

            if (expression is not null)
                query = query.Where(expression);

            var entry = await query.FirstOrDefaultAsync(cancellationToken);

            if (entry is null)
                throw new NotFoundException("Not found");

            return entry;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}
