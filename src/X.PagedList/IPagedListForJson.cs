using System;
using System.Collections.Generic;
using System.Linq;

namespace X.PagedList
{
    public class PagedListForJson<T> : IPagedList
    {
        public int PageCount { get; set; }

        public int TotalItemCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage { get; set; }

        public int FirstItemOnPage { get; set; }

        public int LastItemOnPage { get; set; }

        public IEnumerable<T> Items { get; set; }
    }

    public static class PagedListForJsonExtensions
    {
        public static PagedListForJson<T> ToPagedListForJson<T>(this IPagedList<T> page)
        {
            return new PagedListForJson<T>
            {
                PageCount = page.PageCount,
                TotalItemCount = page.TotalItemCount,
                PageNumber = page.PageNumber,
                FirstItemOnPage = page.FirstItemOnPage,
                LastItemOnPage = page.LastItemOnPage,
                HasNextPage = page.HasNextPage,
                HasPreviousPage = page.HasPreviousPage,
                IsFirstPage = page.IsFirstPage,
                IsLastPage = page.IsLastPage,
                PageSize = page.PageSize,
                Items = page.ToList()
            };
        }

        public static PagedListForJson<TDst> ToPagedListForJson<TSrc, TDst>(this IPagedList<TSrc> page, Func<TSrc, TDst> convert)
        {
            return new PagedListForJson<TDst>
            {
                PageCount = page.PageCount,
                TotalItemCount = page.TotalItemCount,
                PageNumber = page.PageNumber,
                FirstItemOnPage = page.FirstItemOnPage,
                LastItemOnPage = page.LastItemOnPage,
                HasNextPage = page.HasNextPage,
                HasPreviousPage = page.HasPreviousPage,
                IsFirstPage = page.IsFirstPage,
                IsLastPage = page.IsLastPage,
                PageSize = page.PageSize,
                Items = page.Select(x => convert(x)).ToList()
            };
        }

    }
}
