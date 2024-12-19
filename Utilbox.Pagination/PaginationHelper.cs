using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilbox.Pagination
{
    public static class PaginationHelper
    {
        /// <summary>
        /// Creates a paginated result from a collection of items.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="items">The source collection of items.</param>
        /// <param name="pageNumber">The current page number (1-based index).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A PaginatedResult containing the requested page and metadata.</returns>
        public static PaginatedResult<T> Paginate<T>(IEnumerable<T> items, uint pageNumber, uint pageSize)
        {
            var enumerable = items.ToList();
            var totalItems = (uint)enumerable.Count();
            var totalPages = (uint)Math.Ceiling(totalItems / (double)pageSize);
            var pagedItems = enumerable.Skip(((int)pageNumber - 1) * (int)pageSize).Take((int)pageSize).ToList();
            return new PaginatedResult<T>(pagedItems, pageNumber, pageSize, totalItems, totalPages);
        }

        /// <summary>
        /// Creates a paginated result from an IQueryable source, optimized for database queries.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="query">The IQueryable source of items.</param>
        /// <param name="pageNumber">The current page number (1-based index).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A PaginatedResult containing the requested page and metadata.</returns>
        public static PaginatedResult<T> PaginateAsync<T>(IQueryable<T> query, uint pageNumber,
            uint pageSize)
        {
            return Paginate(query, pageNumber, pageSize);
        }
    }
}