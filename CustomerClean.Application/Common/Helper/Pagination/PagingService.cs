using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Common.Helper.Pagination
{
    public class PagingService<TEntity>
        where TEntity : class

    {
        public async Task<PagedList<TEntity>> GetPagedAsync(int pageNumber, int pageSize, IQueryable<TEntity> query, CancellationToken cancellationToken)
        {
            if (pageSize <= 0)
                pageSize = 10;

            var rowsCount = query.Count();

            if (rowsCount <= pageSize || pageNumber <= 1)
                pageNumber = 1;

            return await PagedList<TEntity>.CreateAsync(query, pageNumber, pageSize, rowsCount, cancellationToken);
        }

        public PagedList<TEntity> GetPaged(int pageNumber, int pageSize, IQueryable<TEntity> query)
        {
            if (pageSize <= 0)
                pageSize = 10;

            var rowsCount = query.Count();

            if (rowsCount <= pageSize || pageNumber <= 1)
                pageNumber = 1;

            return PagedList<TEntity>.Create(query, pageNumber, pageSize, rowsCount);
        }


    }
}