using System.Collections.Generic;
using System.Linq;

namespace Utilbox.Pagination
{
    /// <summary>
    /// Represents a paginated result with metadata.
    /// </summary>
    /// <typeparam name="T">The type of the items in the paginated result.</typeparam>
    public sealed class PaginatedResult<T>
    {
        /// <summary>
        /// The items on the current page.
        /// </summary>
        public IReadOnlyCollection<T> Items { get; }

        /// <summary>
        /// The current page number (1-based index).
        /// </summary>
        public uint PageNumber { get; }

        /// <summary>
        /// The size of the page (number of items per page).
        /// </summary>
        public uint PageSize { get; }

        /// <summary>
        /// The total number of items across all pages.
        /// </summary>
        public uint TotalItems { get; }

        /// <summary>
        /// The total number of pages.
        /// </summary>
        public uint TotalPages { get; }

        /// <summary>
        /// Indicates whether there is a next page.
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;

        /// <summary>
        /// Indicates whether there is a previous page.
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;

        /// <summary>
        /// Initializes a new instance of the PaginatedResult class.
        /// </summary>
        /// <param name="items">The items on the current page.</param>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="totalItems">The total number of items across all pages.</param>
        /// <param name="totalPages">The total number of pages.</param>
        public PaginatedResult(IEnumerable<T> items, uint pageNumber, uint pageSize, uint totalItems, uint totalPages)
        {
            Items = items.ToList().AsReadOnly();
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }
    }
}