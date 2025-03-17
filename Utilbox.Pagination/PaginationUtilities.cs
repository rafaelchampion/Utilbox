using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilbox.Pagination;

/// <summary>
/// Provides extension methods for paginating collections.
/// </summary>
public static class PaginationUtilities
{
    /// <summary>
    /// Paginates an in-memory collection.
    /// </summary>
    /// <typeparam name="T">The type of the collection items.</typeparam>
    /// <param name="source">The source collection.</param>
    /// <param name="pageNumber">The current page number (1-based index).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A PaginatedResult containing the requested page and metadata.</returns>
    public static PaginatedResult<T> ToPaginatedResult<T>(this IEnumerable<T> source, uint pageNumber, uint pageSize)
    {
        if (pageNumber < 1)
            throw new ArgumentException("Page number must be at least 1.", nameof(pageNumber));
        if (pageSize < 1)
            throw new ArgumentException("Page size must be greater than 0.", nameof(pageSize));

        var list = source.ToList();
        uint totalItems = (uint)list.Count;
        uint totalPages = (uint)Math.Ceiling(totalItems / (double)pageSize);
        var items = list.Skip(((int)pageNumber - 1) * (int)pageSize).Take((int)pageSize);
        return new PaginatedResult<T>(items, pageNumber, pageSize, totalItems, totalPages);
    }

    ///// <summary>
    ///// Asynchronously paginates an IQueryable source.
    ///// Requires Microsoft.EntityFrameworkCore for async operations.
    ///// </summary>
    ///// <typeparam name="T">The type of the items.</typeparam>
    ///// <param name="source">The IQueryable source.</param>
    ///// <param name="pageNumber">The current page number (1-based index).</param>
    ///// <param name="pageSize">The number of items per page.</param>
    ///// <returns>A Task of PaginatedResult containing the requested page and metadata.</returns>
    //public static async Task<PaginatedResult<T>> ToPaginatedResultAsync<T>(this IQueryable<T> source, uint pageNumber, uint pageSize)
    //{
    //    if (pageNumber < 1)
    //        throw new ArgumentException("Page number must be at least 1.", nameof(pageNumber));
    //    if (pageSize < 1)
    //        throw new ArgumentException("Page size must be greater than 0.", nameof(pageSize));

    //    uint totalItems = (uint)await source.CountAsync();
    //    uint totalPages = (uint)Math.Ceiling(totalItems / (double)pageSize);
    //    var items = await source.Skip(((int)pageNumber - 1) * (int)pageSize).Take((int)pageSize).ToListAsync();
    //    return new PaginatedResult<T>(items, pageNumber, pageSize, totalItems, totalPages);
    //}
}