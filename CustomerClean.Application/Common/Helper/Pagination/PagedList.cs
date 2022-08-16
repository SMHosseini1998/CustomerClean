using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Common.Helper.Pagination
{
    public class PagedList<T> : Result.Result
    {
        public int CurrentPage { get; }

        public int TotalPages { get; }

        public int PageSize { get; }

        public int TotalSize { get; }

        public List<T> Data { get; set; }
        public PagedList(List<T> data) => Data = data;

        public PagedList(bool successed, IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            TotalSize = count;
            PageSize = pageSize;
            Succeeded = successed;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Data = items.ToList();
        }

        public PagedList<TDest> MapTo<TDest>(IMapper mapper)
        {
            var items = mapper.Map<List<TDest>>(Data);
            return new PagedList<TDest>(true, items, TotalSize, CurrentPage, PageSize);
        }

        public static PagedList<T> Create(IQueryable<T> query, int pageNumber, int pageSize, int count)
        {
            var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(true, items, count, pageNumber, pageSize);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int pageNumber, int pageSize, int count,
            CancellationToken cancellationToken)
        {
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            return new PagedList<T>(true, items, count, pageNumber, pageSize);
        }

        public static PagedList<T> CreateAsync(IEnumerable<T> query, int pageNumber, int pageSize, int count)
        {
            var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new PagedList<T>(true, items, count, pageNumber, pageSize);
        }
    }
}